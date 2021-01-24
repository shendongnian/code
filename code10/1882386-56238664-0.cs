C#
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
using System.Windows;
namespace ADTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PowerShell _powershell;
        public PowerShell PowerShell
        {
            get { return _powershell; }
            set { _powershell = value; }
        }
        
        public MainWindow()
        {
            InitializeComponent();
            // Initiate new PowerShell session and import modules
            string[] psModule = { "activedirectory" };
            PowerShell = NewPowerShellSession(psModule);
            // Add list of AD Groups
            var groups = ListADGroup();
            ADGroup.ItemsSource = groups;
        }
        // New PowerShell Session, optionally with module(s)
        private PowerShell NewPowerShellSession(String[] PSModule = null)
        {
            // Define our PowerShell Session
            PowerShell powerShell = PowerShell.Create();
            // Add a runspace to import the module if required.
            if (PSModule != null)
            {
                InitialSessionState initial = InitialSessionState.CreateDefault();
                initial.ImportPSModule(PSModule);
                Runspace runspace = RunspaceFactory.CreateRunspace(initial);
                runspace.Open();
                powerShell.Runspace = runspace;
            } 
            return powerShell;
        }
        // PowerShell function
        private Collection<PSObject> RunPSASync(String PSCommand, IDictionary<String, Object> Parameters, String Property)
        {
            // Sleep two seconds before proceeding.
            PowerShell.AddCommand("Start-Sleep").AddParameter("Seconds", 2).AddStatement();
            // Run our command adding the parameters one by one and then pipe in to Out-String.
            PowerShell.AddCommand(PSCommand);
            if (Parameters != null)
            {
                foreach (var key in Parameters.Keys)
                {
                    PowerShell.AddParameter(key, Parameters[key]);
                }
            }
            // List a selected property
            if (Property != null)
            {
                PowerShell.AddCommand("Select-Object").AddParameter("ExpandProperty", Property);
            }
            // Invoke our command asynchronously and return the objects.
            IAsyncResult async = PowerShell.BeginInvoke();
            var returnCollection = new Collection<PSObject>();
            foreach (PSObject obj in PowerShell.EndInvoke(async))
            {
                returnCollection.Add(obj);
            }
            return returnCollection;
        }
        // PowerShell function with pipeline
        private Collection<PSObject> RunPSASyncPipe(String PSCommand, IDictionary<String, Object> Parameters, String PSCommand2, IDictionary<String, Object> Parameters2, String Property)
        {
            // Sleep two seconds before proceeding.
            PowerShell.AddCommand("Start-Sleep").AddParameter("Seconds", 2).AddStatement();
            // Run our command adding the parameters one by one and then pipe in to Out-String.
            PowerShell.AddCommand(PSCommand);
            if (Parameters != null)
            {
                foreach (var key in Parameters.Keys)
                {
                    PowerShell.AddParameter(key, Parameters[key]);
                }
            }
            // Add the second command in the pipeline
            PowerShell.AddCommand(PSCommand2);
            if (Parameters2 != null)
            {
                foreach (var key in Parameters2.Keys)
                {
                    PowerShell.AddParameter(key, Parameters2[key]);
                }
            }
            // List a selected property
            if (Property != null)
            {
                PowerShell.AddCommand("Select-Object").AddParameter("ExpandProperty", Property);
            }
            // Invoke our command asynchronously and return the objects.
            IAsyncResult async = PowerShell.BeginInvoke();
            var returnCollection = new Collection<PSObject>();
            foreach (PSObject obj in PowerShell.EndInvoke(async))
            {
                returnCollection.Add(obj);
            }
            return returnCollection;
        }
        // List all AD Groups in a specific OU
        private IEnumerable<PSObject> ListADGroup()
        {
            // Define Searchbase
            IDictionary<String, Object> parameters = new Dictionary<String, Object>();
            parameters.Add("Filter", "*");
            parameters.Add("SearchBase", "OU=SomeOtherOU,OU=topOU,DC=blah,DC=com");
            var adGroups = RunPSASync("Get-ADGroup", parameters, "Name");
            return adGroups;
        }
        // Action when ADGroup combobox gets closed
        private void ADGroup_DropDownClosed(object sender, EventArgs e)
        {
            // Collect the currently selected Edge device
            string adGroupName = ADGroup.SelectedItem.ToString();
            IDictionary<String, Object> groupParameters = new Dictionary<String, Object>();
            groupParameters.Add("Filter", "*");
            groupParameters.Add("SearchBase", "OU=SomeOtherOU,OU=topOU,DC=blah,DC=com");
            IDictionary<String, Object> memberParameters = new Dictionary<String, Object>();
            memberParameters.Add("Name", adGroupName);
            var adMembers = RunPSASyncPipe("Get-ADGroup", groupParameters, "Get-ADGroupMember", memberParameters, "name");
            ADGroupMember.ItemsSource = adMembers;
        }
    }
}
