using System;
using System.Security;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
public bool CreateMailContact(string firstName, string lastName, string alias, string email)
    {
      string fullName = firstName + " " + lastName;
      string address = "SMTP:" + ExternalEmail;
      RunspaceConfiguration runspacesConfig = RunspaceConfiguration.Create();
 
      PSSnapInException snapInException = null;
      PSSnapInInfo info = runspaceConfig.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.SnapIn", out snapInException);
      Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfig);
      runspace.Open();
      Pipeline pipeline = runspace.CreatePipeline();
 
      Command createCommand = new Command("New-MailContact");
      createCommand.Parameters.Add("ExternalEmailAddress", address);
      createCommand.Parameters.Add("Name", name);
      createCommand.Parameters.Add("Alias", alias);
      createCommand.Parameters.Add("FirstName", firstName);
      createCommand.Parameters.Add("LastName", lastName);
      pipeline.Commands.Add(createCommand);
      try
      {
        pipeline.Invoke();
      }
      catch (Exception ex)
      {
        Console.WriteLine("An error occurred.")
      }
      finally
      {
        runspace.Dispose();
        return true;
      }
      return false;
    }
  [1]: https://docs.microsoft.com/en-us/powershell/exchange/exchange-server/open-the-exchange-management-shell?view=exchange-ps
