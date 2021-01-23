    // make sure a SC is created automatically
    Forms.WindowsFormsSynchronizationContext.AutoInstall = true;
    // a control needs to exist prior to getting the SC for WinForms
    // (any control will do)
    var syncControl = new Forms.Control();
    syncControl.CreateControl();
    SyncrhonizationContext winformsContext = System.Threading.SynchronizationContext.Current;
