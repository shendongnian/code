        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Diagnostics;
        using System.Linq;
        using System.ServiceProcess;
        using System.Text;
        using System.Threading.Tasks;
        using System.Timers;
        using System.Runtime.InteropServices;
        
        namespace SomeService
        {
    
          public partial class Service1 : ServiceBase
          {
    		private List<Process> _processes;
            public Service1()
            {
    			InitializeComponent();
    			_processes = new List<Process>();
            }
        
            protected override void OnStart(string[] args)
            {
              var process = Process.Start("C:\\Users\\JohnnySmalls\\SomeProgram\\bin\\theExe.exe");
    		  _processes.Add(process);
            }
        
            protected override void OnStop()
            {
              // Need to close process, I don't have a reference to it though
              // Process.Close();
    			foreach(var process in _processes) {
    				process.Close();
    			}
            }
          }
        }
