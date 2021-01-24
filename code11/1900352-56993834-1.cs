            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using EnvDTE100;
            using System.IO;
            using TCatSysManagerLib;
            
            namespace ActivatePreviousConfiguration{
            
            	class Program
            	{
            
            		static void Main(string[] args)
            		{
            			Type t = System.Type.GetTypeFromProgID("VisualStudio.DTE.10.0");
            			EnvDTE.DTE dte = (EnvDTE.DTE)System.Activator.CreateInstance(t);
            			dte.SuppressUI = false;
                        dte.MainWindow.Visible = true;
            			EnvDTE.Solution sol = dte.Solution;
            			sol.Open(@"C:\Temp\SolutionFolder\MySolution1\MySolution1.sln");
            
            			EnvDTE.Project pro = sol.Projects.Item(1);
            			ITcSysManager sysMan = pro.Object;
                        sysMan.ActivateConfiguration();
            			sysMan.StartRestartTwinCAT();
            		}
            	}
            }
