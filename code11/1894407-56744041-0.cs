    using System;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    public static class TestApplication {
        public static void Main() {
            Console.WriteLine(Environment.Is64BitProcess);
            using(PowerShellProcessInstance pspi = new PowerShellProcessInstance()) {
                string psfn = pspi.Process.StartInfo.FileName;
                psfn=psfn.ToLowerInvariant().Replace("\\syswow64\\", "\\sysnative\\");
                pspi.Process.StartInfo.FileName=psfn;
                using(Runspace r = RunspaceFactory.CreateOutOfProcessRunspace(null, pspi)) {
                    r.Open();
                    using(PowerShell ps = PowerShell.Create()) {
                        ps.Runspace=r;
                        ps.AddScript("[Environment]::Is64BitProcess");
                        foreach(PSObject pso in ps.Invoke()) {
                            Console.WriteLine(pso);
                        }
                    }
                }
            }
        }
    }
