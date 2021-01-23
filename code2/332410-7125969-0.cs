    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ output extension=".cs" #>
    <#@ assembly name="EnvDTE" #>
    <#@ import namespace="EnvDTE"#>
    <#@ import namespace="System"#>
    <#@ import namespace="System.IO"#>
    <#@ import namespace="System.Collections.Generic"#>
    <#
    	// Global Variables (Config)
    	var ContentProjectName = "GameContent";
    	List<string> AcceptableFileExtensions = new List<string>(){".png"};
    
    	// Program
    	IServiceProvider serviceProvider = (IServiceProvider)this.Host;
    	DTE dte = (DTE) serviceProvider.GetService(typeof(DTE));
        
        Project activeProject = null;
    
    	foreach(Project p in dte.Solution.Projects)
    	{
    		if(p.Name == ContentProjectName)
    		{
    			activeProject = p;
    			break;
    		}
    	}
    
    	emitProject(activeProject, AcceptableFileExtensions);
    #>
    
    <#+
    private void emitProject(Project p, List<string> acceptableFileExtensions)
    {
    	this.Write("namespace GameContent\r\n{\r\n");
    	foreach(ProjectItem i in p.ProjectItems)
    	{
    		emitProjectItem(i, 1, acceptableFileExtensions);
    	}
    	this.Write("}\r\n");
    }
    
    private void emitProjectItem(ProjectItem p, int indentDepth, List<string>         acceptableFileExtensions)
    {
    	if(String.IsNullOrEmpty(Path.GetExtension(p.Name)))
    	{
    		emitDirectory(p, indentDepth, acceptableFileExtensions);
    	}
    	else if(acceptableFileExtensions.Contains(Path.GetExtension(p.Name)))
    	{
    		emitFile(p, indentDepth);
    	}
    }
    
    private void emitDirectory(ProjectItem p, int indentDepth, List<string>     acceptableFileExtensions)
    {
    	emitIndent(indentDepth);
    	this.Write("/// Directory: " + Path.GetFullPath(p.Name) + "\r\n");
       	emitIndent(indentDepth);
    	this.Write("namespace " + Path.GetFileNameWithoutExtension(p.Name) + "\r\n");
    	emitIndent(indentDepth);
    	this.Write("{" + "\r\n");
    
    	foreach(ProjectItem i in p.ProjectItems)
    	{
        	emitProjectItem(i, indentDepth + 1, acceptableFileExtensions);
    	}
    
    	emitIndent(indentDepth);
    	this.Write("}" + "\r\n" + "\r\n");
    }
    
    private void emitFile(ProjectItem p, int indentDepth)
    {
    	emitIndent(indentDepth);
    	this.Write("/// File: " + Path.GetFullPath(p.Name) + "\r\n");
        emitIndent(indentDepth);
    	this.Write("public static class " + Path.GetFileNameWithoutExtension(p.Name) +     "\r\n");
    	emitIndent(indentDepth);
    	this.Write("{" + "\r\n");
    
    	emitIndent(indentDepth + 1);
    	this.Write("public static readonly string Path      = @\"" +     Path.GetDirectoryName(Path.GetFullPath(p.Name)) + "\";" + "\r\n");
    	emitIndent(indentDepth + 1);
    	this.Write("public static readonly string Extension = @\"" +     Path.GetExtension(p.Name) + "\";" + "\r\n");
    	emitIndent(indentDepth + 1);
    	this.Write("public static readonly string Name      = @\"" +     Path.GetFileNameWithoutExtension(p.Name) + "\";" + "\r\n");
    
    	emitIndent(indentDepth);
    	this.Write("}" + "\r\n" + "\r\n");
    }
    
    private void emitIndent(int depth)
    {
    	for(int i = 0; i < depth; i++)
    	{
    		this.Write("\t");
    	}
    }
    #>
    
