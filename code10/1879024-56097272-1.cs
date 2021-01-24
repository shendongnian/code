private string GetTfLocation()
{
    string tfPath = "";
    // For VS 2015
    if (File.Exists(tfPath = @"C:\Program Files (x86)\Microsoft Visual Studio 2014\Common7\IDE]tf.exe"))
        return tfPath;
    // For VS 2017 Professional version
    if (File.Exists(tfPath = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\CommonExtensions\Microsoft\TeamFoundaion\Team Explorer\Tf.exe"))
        return thPath;
    // And list all VS versions like above
    return null;
}
2) Ask the user to enter the location or which VS version he has and generate the version (in the second option need also to update the code with each new VS version):
Create a new TextBox, give a name (for example: `tfExeTxtBox`), in your code get the value:
string tfExeLoacation = tfExeTxtBox.Text;
3) Use TFS DLL's to do the actions and not start `tf.exe` process:
You need 2 DLL's (available in NuGet):
Microsoft.TeamFoundation.Client
Microsoft.TeamFoundation.VersionControl.Client
Now you can do all TFVC action, for example:
TfsTeamProjectcollection tfs = new TfsTeamProjectColletion(new Uri("tfs-server-url"));
VersionControlServer versionControl = (VersionControlServer)tfs.GetService(typeof(VersionControlServer));
Workspace workspace = versionControl.CreateWorkspace("newWorkSpace", "user name");
// Add to pending changes
workspace.PendAdd("workspace path");
var changes = workspace.GetPendingChanges();
// Check In
workspace.CheckIn(changes, "comment");
