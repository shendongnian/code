    using System;
    using System.Diagnostics;
    using System.IO;
    
    using Agility.Server.Scripting.ScriptAssembly;
    
    namespace MyNamespace
    {
    
        public class Class1
        {
          public Class1() 
          {
          }
    
          [StartMethodAttribute()] 
          public void Method1(ScriptParameters sp) 
          {
              string pattern = @"\|";
              string parameter =sp.InputVariables["[Facture.InstanceID]"].ToString();
              using (Process process = new Process())
              {
                  process.StartInfo.UseShellExecute = false;
                  process.StartInfo.RedirectStandardOutput = true;
                  process.StartInfo.FileName = "java";
                  process.StartInfo.Arguments = @"-jar C:\\jars\\application.jar " + parameter;
                  process.Start();
                  StreamReader reader = process.StandardOutput;
                  string output = reader.ReadToEnd();
                  process.WaitForExit();
                  string[] results = Regex.Split(output, pattern, RegexOptions.IgnoreCase);
             	  sp.OutputVariables["responseCode"] = results[0];
             	  sp.OutputVariables["statusCode"] = results[1];
              }
          }
       }
    }
