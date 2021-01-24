public void MethodThatLoadDll()
{
    AppDomain dom = null;
    //declare this outside the try-catch block, so we can unload it in finally block
    try
    {
        string domName = "new:" + Guid.NewGuid();
        //assume that the domName is "new:50536e71-51ad-4bad-9bf8-67c54382bb46"
        //create the new domain here instead of in the proxy class
        dom = AppDomain.CreateDomain(, null, new AppDomainSetup
                    {
                        PrivateBinPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin"),
                        ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
                        ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,
                        ApplicationName = AppDomain.CurrentDomain.SetupInformation.ApplicationName,
                        ShadowCopyFiles = "true",
                        ShadowCopyDirectories = "true",/*yes they are string value*/
                        LoaderOptimization = LoaderOptimization.SingleDomain,
                        DisallowBindingRedirects = false,
                        DisallowCodeDownload = true,
                    });
        ProxyClass proxy = (ProxyClass)dom.CreateInstanceAndUnwrap(
                    typeof(ProxyClass).Assembly.FullName, typeof(ProxyClass).FullName);
        string result = proxy.ExecuteAssembly("MyParam");
        /*Do whatever to the result*/
    }
    catch(Exception ex)
    {
        //handle the error here
    }
    finally
    {
        //finally unload the app domain
        if(dom != null) AppDomain.Unload(dom);
    }
}
My class that inherits `MarshalByRefObject`
C#
private class ProxyClass : MarshalByRefObject
{
    //you may specified any parameter you want, if you get `xxx is not marked as serializable` error, see explanation below
    public string ExecuteAssembly(string param1)
    {
        /*
         * All the code executed here is under the new app domain that we just created above
         * We also have different session state here, so if you want data from main domain's session, you should pass it as a parameter
         */
        //load your DLL file here
        Debug.WriteLine(AppDomain.CurrentDomain.FriendlyName);
        //will print "new:50536e71-51ad-4bad-9bf8-67c54382bb46" which is the name that we just gave to the new created app domain
        
        Assembly asm = Assembly.LoadFrom(@"PATH/TO/THE/DLL");
        Type baseClass = asm.GetType("MyAssembly.MyClass");
        MethodInfo targetMethod = baseClass.GetMethod("MyMethod");
        string result = targetMethod.Invoke(null, new object[]{});
        return result;
    }
}
A common error that you may run into
'xxx' is not marked as serializable
This could happen if you try to pass a custom class as parameter, like this
C#
public void ExecuteAssembly(MyClass param1)
In this case, put a `[Serializable]` to `MyClass`, like this
C#
[Serializable]
public class MyClass { }
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.appdomain.createinstanceandunwrap?view=netframework-4.8#System_AppDomain_CreateInstanceAndUnwrap_System_String_System_String_
  [2]: https://stackoverflow.com/questions/14479074/c-sharp-reflection-load-assembly-and-invoke-a-method-if-it-exists
  [3]: https://stackoverflow.com/questions/6578170/using-appdomain-in-c-sharp-to-dynamically-load-and-unload-dll
