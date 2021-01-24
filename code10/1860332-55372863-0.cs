    using Microsoft.Deployment.WindowsInstaller;
    ...
    var project = new Project("Application Name", GetAllEntities(releaseDir, parentDir, out service));
    ...
    private static Dir GetDirs(string releaseDir, string parentDir, out File service)
            {
                var docDir = System.IO.Path.GetFullPath(System.IO.Path.Combine(parentDir, @"pub\\doc\\"));
                return new Dir(new Id("SERVICEDIR"), @"%ProgramFiles%\Application\",
                new Dir(new Id("INSTALLSERVICEDIR"), "App name",
                    new Dir(new Id("BINSERVICEDIR"), "bin",
        ...
                        new File(string.Format("{0}{1}", releaseDir, "Admin.exe")),
    ...
    project.AddAction(new ManagedAction(CustomActions.MyAction, Return.check, When.After, Step.InstallFinalize, Condition.NOT_Installed));
    ...
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult MyAction(Session session)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = string.Format("{0}\\Admin.exe", session["BINSERVICEDIR"]);
            process.StartInfo.Arguments = "-n";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
            process.WaitForExit();
            return ActionResult.Success;
        }
    }
