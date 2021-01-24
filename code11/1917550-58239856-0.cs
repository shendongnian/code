    <#@ template debug="true" hostspecific="true" language="C#" #>
    <#@ output extension=".sql" #>
    <#@ assembly name="Microsoft.VisualBasic.dll" #>
    <#@ assembly name="EnvDTE" #>
    <#@ import Namespace="System.IO" #>
    <#@ import Namespace="System.Text.RegularExpressions" #>
    <#@ import namespace="EnvDTE" #>
    
    <#
    	var migrationName = Microsoft.VisualBasic.Interaction.InputBox("InputBox Label", "Description");
    	
    	Regex alphaNumericRegex = new Regex("[^a-zA-Z0-9-_]");
    	migrationName = alphaNumericRegex.Replace(migrationName, string.Empty);
    
    	if (string.IsNullOrWhiteSpace(migrationName))
    		return "";
    
    	var migrationVersion = System.DateTime.Now.ToString("yyyyMMddHHmm");
    	var migrationFileName = migrationVersion + "-InsertCourt" + migrationName + ".sql";
    	var migrationFilePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Host.TemplateFile), migrationFileName));
    #>
    
    My T4 template goes here
    
    <#
    SaveOutput(migrationFilePath);
    IncludeInCurrentProject(migrationFilePath)
    	.Open(Constants.vsViewKindPrimary)
    	.Activate();
    #>
    <#+
    	private void SaveOutput(string filename)
    	{
    		File.WriteAllText(filename, GenerationEnvironment.ToString());
    		GenerationEnvironment.Clear();
    	}
    
    	private ProjectItem IncludeInCurrentProject(string filename)
    	{
    		ProjectItem item = GetCurrentProjectItem().ProjectItems.AddFromFile(filename);
    		item.Properties.Item("BuildAction").Value = "None";
    		return item;
    	}
    
    	private ProjectItem GetCurrentProjectItem()
    	{
    
    		var serviceProvider = (IServiceProvider)this.Host;
    		var dte = serviceProvider.GetService(typeof(DTE)) as DTE;
    
    		string templateDirectory = Path.GetDirectoryName(Host.TemplateFile);
    		string foldersString = templateDirectory.Replace(Path.GetDirectoryName(GetCurrentProject().FullName), string.Empty);
    		string[] foldersArray = foldersString.Split(new [] {"\\"}, StringSplitOptions.RemoveEmptyEntries);
    
    		foreach(Project project in dte.Solution.Projects) 
    		{
    			ProjectItems currentProjectItems = null;
    
    			foreach(string folder in foldersArray)
    			{
    				if(currentProjectItems == null) 
    				{
    					currentProjectItems = project.ProjectItems;
    				}
    
    				foreach(ProjectItem projectItem in currentProjectItems) 
    				{
    					if(projectItem.Name == folder) 
    					{
    						if(Array.IndexOf(foldersArray, folder) == foldersArray.Length - 1)
    						{
    							return projectItem;
    						}
    						currentProjectItems = projectItem.ProjectItems;
    						break;
    					}
    				}
    			}
    		}
    		return null;
    	}
    
    	private Project GetCurrentProject()
    	{
    		var serviceProvider = (IServiceProvider)this.Host;
    		var dte = serviceProvider.GetService(typeof(DTE)) as DTE;
    
    		foreach(Project project in dte.Solution.Projects) 
    		{
    			// workaround. dte.Solution.FindProjectItem(Host.TemplateFile).ContainingProject didn't work
    			string directory = Path.GetDirectoryName(project.FullName);
    			if(Host.TemplateFile.Contains(directory))
    			{
    				return project;
    			}
    		}
    		return null;
    	}
    
    
    	private ProjectItem _currentProjectItem;
    #>
