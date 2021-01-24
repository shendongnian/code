    protected override void Initialize ()
    {
      MyExtension.Initialize (this);
      base.Initialize ();
      MyExtension.Instance.DTEObject = (EnvDTE.DTE)base.GetService (typeof (Microsoft.VisualStudio.Shell.Interop.SDTE));
    }
