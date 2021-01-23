    using System;
    using System.Diagnostics;
    class ProcessStart{
        static void Main(string[] args){
        
            Process sample = new Process();
            sample.StartInfo.FileName   = "sample.exe";
            sample.Start();
        }
    }
