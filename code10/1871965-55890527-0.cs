    using EnvDTE;
    using EnvDTE80;
    using System.Windows.Forms;
    using System.Diagnostics;
    
    public class C : VisualCommanderExt.ICommand
    {
    	public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
    	{
            this.DTE = DTE;
    
            AnnotateAllInterfacesAndMethods("Console1");
             
        }
    
    
        private void AnnotateAllInterfacesAndMethods(string projectName)
        {
            var res = AllClasses(projectName);
            foreach (EnvDTE.CodeInterface c in res)
            { 
                //ADD attributes
                if (c.Attributes.Count == 0)
                {
                    c.AddAttribute("System.ServiceModel.ServiceContract", $"Name=\"{c.Name}\"");                 
                }
                else  
                {
                    bool broken = false;
                    var items = c.Attributes.GetEnumerator();
                    while (items.MoveNext())
                    {
                        CodeElement value = (CodeElement)items.Current;
                       
                        if (value.Name == "ServiceContract")
                        { 
                            broken = true;
                            break;
                        }
                    }
                    //service contract not found. So we add it.
                    if (!broken)
                    {
                        c.AddAttribute("System.ServiceModel.ServiceContract", $"Name=\"{c.Name}\"");                    
                    }
                }
    
    
                if (c.Members.Count > 0)
                {
                    foreach (EnvDTE.CodeElement m in c.Members)
                    {
                        if (m.Kind == EnvDTE.vsCMElement.vsCMElementFunction)
                        {
                            var func = (m as EnvDTE.CodeFunction);
    
                            if (func.Attributes.Count == 0)
                            {
                                func.AddAttribute("System.ServiceModel.OperationContract", $"Name=\"{func.Name}\"");
                            }
                            else
                            {
                                bool broken = false;
                                var items = func.Attributes.GetEnumerator();
                                while (items.MoveNext())
                                {
                                    CodeElement value = (CodeElement)items.Current;
    
                                    if (value.Name == "OperationContract")
                                    {
                                        broken = true;
                                        break;
                                    }
                                }
                                //OperationContract not found. So we add it.
                                if (!broken)
                                {
                                    func.AddAttribute("System.ServiceModel.OperationContract", $"Name=\"{func.Name}\"");
                                }
                            }
    
                        }
                    }
                }
            }
            System.Windows.MessageBox.Show("Done");
        }
    
        private System.Collections.Generic.List<EnvDTE.CodeInterface> AllClasses(string projectName)
        {
            System.Collections.Generic.List<EnvDTE.CodeInterface> result = new System.Collections.Generic.List<EnvDTE.CodeInterface>();
           
            foreach (EnvDTE.Project p in DTE.Solution.Projects)
            { 
                if (projectName == p.Name)
                { 
                    EnumerateProjectItems(p.ProjectItems, result);
                }
            }
            return result;
        }
    
        private void EnumerateProjectItems(EnvDTE.ProjectItems items, System.Collections.Generic.List<EnvDTE.CodeInterface> result)
        {
            foreach (EnvDTE.ProjectItem i in items)
            { 
                if (i.FileCodeModel != null && i.FileCodeModel.CodeElements != null)
                {
                    
                    foreach (EnvDTE.CodeElement n in i.FileCodeModel.CodeElements)
                    { 
                        if (n.Kind == EnvDTE.vsCMElement.vsCMElementNamespace)
                        {
                            foreach (EnvDTE.CodeElement c in (n as EnvDTE.CodeNamespace).Members)
                            {
                                if (c.Kind == EnvDTE.vsCMElement.vsCMElementInterface)
                                { 
                                    result.Add(c as EnvDTE.CodeInterface);
                                }
                            }
                        } 
                    }
                }
                if (i.ProjectItems != null)
                    EnumerateProjectItems(i.ProjectItems, result);
            }
        }
    
        private EnvDTE80.DTE2 DTE;
    }
