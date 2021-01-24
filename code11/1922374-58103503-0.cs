    public class C : VisualCommanderExt.ICommand
    {
    	public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
    	{
            EnvDTE.TextSelection ts = DTE.ActiveWindow.Selection as EnvDTE.TextSelection;
            if (ts == null)
                return;
            EnvDTE.CodeFunction func = ts.ActivePoint.CodeElement[EnvDTE.vsCMElement.vsCMElementFunction] as EnvDTE.CodeFunction;
            if (func == null)
                return;
    
            string result = "";
            foreach(EnvDTE.CodeParameter i in func.Parameters)
            {
                if (result.Length > 0)
                    result += ", ";
                result += i.Name;
            }
            ts.Text = "(" + result + ")";
        }
    }
