    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    
    namespace TestParamHelper
    {
        class Program
        {
            static void Main(string[] args)
            {
                new CallingClass().CallTargetMethod();
            }
        }
    
        public class CallingClass
        {
            public void CallTargetMethod()
            {
                var s = "str";
                var i = 5;
                new TargetClass().TargetMethod(s, i);
            }
        }
    
        public class TargetClass
        {
            public void TargetMethod(string strArg, int intArg)
            {
                var paramName = nameof(strArg);
                // HERE IT IS!!!
                var originalName = ParamNameHelper.GetOriginalVariableName(paramName);
                Console.WriteLine($"{originalName} is passed as {paramName}");
            }
        }
    
        public static class ParamNameHelper
        {
            public static string GetOriginalVariableName(string paramName)
            {
                var stackTrace = new StackTrace(true);
    
                var targetMethod = stackTrace.GetFrame(1).GetMethod();
                var paramIndex = targetMethod.GetParameters().ToList().FindIndex(p => p.Name.Equals(paramName));
    
                var callingMethod = stackTrace.GetFrame(2).GetMethod();
                var il = callingMethod.GetMethodBodyIL();
    
                var localIndex = il
                    .TakeWhile(s => !s.Contains($"{targetMethod.DeclaringType.FullName}::{targetMethod.Name}"))
                    .Reverse()
                    .TakeWhile(s => s.Contains("ldloc"))
                    .Reverse()
                    .ElementAt(paramIndex)
                    .Split('.')
                    .Last();
    
                return il
                    .SkipWhile(s => !s.Contains("locals init"))
                    .TakeWhile(s => s.Contains(",") || s.Contains(")"))
                    .First(s => s.Contains($"[{localIndex}]"))
                    .Replace(")", "")
                    .Replace(",", "")
                    .Split(' ')
                    .Last();
            }
        }
    
        internal static class MethodBaseExtensions
        {
            // improve providing location, may be via config
            private static readonly string ildasmLocation = Path.GetFullPath(@"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.2 Tools\ildasm.exe");
    
            internal static IEnumerable<string> GetMethodBodyIL(this MethodBase method)
            {
                var assemblyLocation = method.DeclaringType.Assembly.Location;
                var ilLocation = $"{assemblyLocation}.il";
    
                Process.Start(new ProcessStartInfo(ildasmLocation, $"{assemblyLocation} /output:{ilLocation}") { UseShellExecute = false })
                    .WaitForExit();
    
                var il = File.ReadAllLines(ilLocation)
                    .SkipWhile(s => !s.Contains(method.Name))
                    .Skip(2)
                    .TakeWhile(s => !s.Contains($"end of method {method.DeclaringType.Name}::{method.Name}"));
    
                File.Delete(ilLocation);
    
                return il;
            }
        }
    }
