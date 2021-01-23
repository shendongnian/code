    using System; 
    using System.Management.Automation; 
     
    [Cmdlet(VerbsCommon.Get,"Hello")] 
    public class GetHelloCommand:Cmdlet 
    { 
        protected override void EndProcessing() 
        { 
            WriteObject("Hello",true); 
        } 
    } 
     
    class MainClass 
    { 
        public static void Main(string[] args) 
        { 
            PowerShell powerShell=PowerShell.Create();
    
            // import commands from the current executing assembly
            powershell.AddCommand("Import-Module")
                .AddParameter("Assembly",
                      System.Reflection.Assembly.GetExecutingAssembly())
            powershell.Invoke()
            powershell.Commands.Clear()
    
            powershell.AddCommand("Get-Hello"); 
            foreach(string str in powerShell.AddCommand("Out-String").Invoke<string>()) 
                Console.WriteLine(str); 
        } 
    } 
