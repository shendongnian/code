    var processStartInfo = new ProcessStartInfo(SATELITE_PATH);
    var pSatelite = Process.Start(processStartInfo);
    pSatelite.WaitForInputIdle();
    Delay(2);
    satelite = AutomationElement.RootElement.FindChildByProcessId(pSatelite.Id);
    AutomationElement loginUser = satelite.FindDescendentByIdPath(new[] {"frmLogin", "txtUserName"});
    if (loginUser != null)
    {
         ValuePattern valPattern = loginUser.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
         valPattern.SetValue(username);
    }
