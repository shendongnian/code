	public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
	{
        EnvDTE.TextSelection ts = DTE.ActiveWindow.Selection as EnvDTE.TextSelection;
        if (ts == null)
            return;
        EnvDTE.CodeClass codeClass = ts.ActivePoint.CodeElement[EnvDTE.vsCMElement.vsCMElementClass]
            as EnvDTE.CodeClass;
        if (codeClass == null)
            return;
        codeClass.AddAttribute("DataContract", null);
        foreach(EnvDTE.CodeElement i in codeClass.Children)
        {
            if (i is EnvDTE.CodeProperty)
                (i as EnvDTE.CodeProperty).AddAttribute("DataMember", null);
        }
    }
