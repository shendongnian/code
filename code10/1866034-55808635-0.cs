namespace ClassLib
{
    public class Class1
    {
        public static string DoWork(string path)
        {
            return System.IO.File.ReadAllText(path);
        }
    }
}
We can invoke it with restricted permissions like that:
using System;
using System.Collections;
using System.Reflection;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;
namespace ConsoleApplication1
{
    class Program
    {
        //Path to plugin library
        public static string libname = @"C:\PROJECTS\ConsoleApp1\bin\Debug\ClassLib.dll";
        //Invokes plugin library in restricted AppDomain
        //Grants access to the directory specified by allowedPath parameter
        static void InvokeLibrary(string allowedPath="")
        {
            var path = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            //create restricted permission set
            Evidence evidence = new Evidence();
            evidence.AddHostEvidence(new Zone(SecurityZone.Internet));
            PermissionSet permissionSet = SecurityManager.GetStandardSandbox(evidence);
            //grant read access to plugin library file, so it can at least load successfully
            permissionSet.AddPermission(new FileIOPermission(FileIOPermissionAccess.Read, libname));
            permissionSet.AddPermission(new FileIOPermission(FileIOPermissionAccess.PathDiscovery, libname));
            //grant read access to
            if (allowedPath != "")
            {
                permissionSet.AddPermission(new FileIOPermission(FileIOPermissionAccess.Read, allowedPath));
            }            
            AppDomainSetup appDomainSetup = new AppDomainSetup();
            appDomainSetup.ApplicationBase = System.IO.Path.GetDirectoryName(path);
            
            //create AppDomain with specified permissions
            AppDomain domain = AppDomain.CreateDomain(
                "MyDomain",
                evidence,
                appDomainSetup,
                permissionSet
                );
            
            //create remoting wrapper
            Type type = typeof(Wrapper);
            Wrapper wrapper = (Wrapper)domain.CreateInstanceAndUnwrap(
                type.Assembly.FullName,
                type.FullName);
            //invoke method          
            InvokeResult res = wrapper.Invoke(libname,"c:\\dir\\file.txt");
            if (res.Success) Console.WriteLine("Invoke result: " + res.Result);
            else {
                Console.WriteLine("Invoke error: " + res.Error.GetType().ToString());
                if (res.Error is SecurityException)
                {
                    Console.WriteLine("Demanded permissions:\n" + (res.Error as SecurityException).Demanded);
                }
            }                    
                        
            AppDomain.Unload(domain);
        }
        static void Main(string[] args)
        {
            //invoke plugin without explicit permissions
            Console.WriteLine("First attempt...");
            InvokeLibrary();
            //invoke plugin with specified directory access
            Console.WriteLine("Second attempt...");
            InvokeLibrary("c:\\dir\\");   
            Console.ReadKey();
        }
    }
    //Object to pass between app domains
    public class InvokeResult : MarshalByRefObject
    {
        public bool Success = false;
        public string Result="";
        public Exception Error =null;
    }
    //Wrapper for remoting
    public class Wrapper : MarshalByRefObject
    {
        public Exception lasterror;
        public InvokeResult Invoke(string lib, string arg)
        {
            InvokeResult res = new InvokeResult();
            try
            {
                //load plugin                
                Assembly ass = Assembly.LoadFile(lib);
                Type t = ass.GetType("ClassLib.Class1");
                MethodInfo mi = t.GetMethod("DoWork", BindingFlags.Static | BindingFlags.Public);
                //invoke plugin method
                res.Result = (string)mi.Invoke(null, new object[] { arg });
                res.Success = true;
                
            }
            catch (TargetInvocationException ex)
            {
                res.Success = false;
                if (ex.InnerException != null) res.Error = ex.InnerException;
                else res.Error = ex;
            }
            return res;
        }
    }
}
/* Output:
First attempt...
Invoke error: System.Security.SecurityException
Demanded permissions:
<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
version="1"
Read="c:\dir\file.txt"/>
Second attempt...
Invoke result: The content of file.txt 
*/
