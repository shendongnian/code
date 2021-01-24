    using EnvDTE;
    using EnvDTE80;
    using Microsoft.VisualBasic;
    
    public class C : VisualCommanderExt.ICommand
    {
    	public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
    	{
            string className = Microsoft.VisualBasic.Interaction.InputBox("Class name", "Create tests",
                        "VATRate", -1, -1);
            EnvDTE.ProjectItem f = DTE.ItemOperations.AddNewItem("Visual C# Items\\Code\\Class", className + "RepositoryTests.cs");
            EnvDTE.CodeClass c = FirstClass(FirstNamespace(f.FileCodeModel.CodeElements).Children);
            c.AddFunction("Insert" + className, vsCMFunction.vsCMFunctionFunction, vsCMTypeRef.vsCMTypeRefVoid);
        }
    
        private EnvDTE.CodeNamespace FirstNamespace(EnvDTE.CodeElements elements)
        {
            foreach(EnvDTE.CodeElement c in elements)
            {
                if(c is EnvDTE.CodeNamespace)
                return c as EnvDTE.CodeNamespace;
            }
            return null;
        }
    
        private EnvDTE.CodeClass FirstClass(EnvDTE.CodeElements elements)
        {
            foreach (EnvDTE.CodeElement c in elements)
            {
                if (c is EnvDTE.CodeClass)
                    return c as EnvDTE.CodeClass;
            }
            return null;
        }
    }
