    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Win32;
    using System.Diagnostics;
    using System.IO;
    namespace ConsoleApplication1
    {
     class Program
     {
       static void Main(string[] args)
       {
           Process process = new Process();
           process.StartInfo.FileName = "C:\\temp\\bin\\fls.exe";
           process.StartInfo.Arguments = "-m C: -r C:\\temp\\image.dd";
           process.StartInfo.UseShellExecute = false;
           process.StartInfo.RedirectStandardOutput = true;
           process.StartInfo.RedirectStandardInput = true;
           process.StartInfo.RedirectStandardError = true;
           process.Start();
           System.IO.StreamReader reader = process.StandardOutput;
           string sRes = reader.ReadToEnd();
           StreamWriter SW;
           SW = File.CreateText("C:\\temp\\ntfs.bodyfile");
           SW.WriteLine(sRes);
           SW.Close();
           Console.WriteLine("File Created SucacessFully");
           reader.Close();  
       }   
      }
    }
