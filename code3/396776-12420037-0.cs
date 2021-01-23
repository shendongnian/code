    using CWDev.SLNTools.Core;
	using SlnFile = CWDev.SLNTools.Core.SolutionFile;
	using SlnProject = CWDev.SLNTools.Core.Project;
	using SeptaCodeGenerator.Core.IO;
	public class SlnFileManager
	{
		// * Note: Sln is of my own type.
		Sln _sln;
		// * SolutionFile is the type in SLNTools project that we use
		SlnFile _slnFile;
		public void WriteNewSlnFile(Sln slnObject)
		{
			_sln = slnObject;
			_slnFile = new SlnFile(); // or you can read sln file like below
			using (SolutionFileReader reader = new SolutionFileReader(_sln.ObjectFullPath))
				_slnFile = reader.ReadSolutionFile();
			AddHeaders();
			AddGlobalSections();
			// add projects
			List<SolutionNode> sns = _sln.GetAllSubItemsOf(typeof(SolutionFolder), typeof(ProjectNode));
			foreach (SolutionNode sn in sns)
				_slnFile.Projects.Add(CreateProject(sn));
			using (SolutionFileWriter writer = new SolutionFileWriter(_sln.ObjectFullPath))
				writer.WriteSolutionFile(_slnFile);
		}
		// this is how I create and add project sections, using Section and PropertyLine
		private SlnProject CreateProject(SolutionNode sn)
		{
			List<Section> projectSections = CreateProjectSections(sn);
			List<PropertyLine> versionControlLines = CreateVersionControlLines(sn);
			List<PropertyLine> projectConfigurationPlatformsLines = CreateProjectConfigurationPlatformsLines(sn);
			string parentGuid = (sn.Parent is Sln ? null : sn.Parent.InstanceGuidSt);
			string relativePath = (sn is Project) ? (sn as Project).ProjFile.ObjectRelativePath : sn.ObjectRelativePath;
			return new CWDev.SLNTools.Core.Project(_slnFile, sn.InstanceGuidSt, sn.TypeGuidSt, sn.Name, relativePath, parentGuid,
				projectSections, versionControlLines, projectConfigurationPlatformsLines);
		}
		// this method creates ProjectSections(WebsiteProperties)
		private List<Section> CreateProjectSections(SolutionNode project)
		{
			Section sec = null;
			var lines = new List<PropertyLine>();
			if (project is SolutionFolder)
			{
				List<SolutionNode> files = project.GetAllSubItemsOf(typeof(SolutionFile));
				foreach (SolutionNode item in files)
				{
					// * consideration required
					lines.Add(new PropertyLine(item.ObjectRelativePath, item.ObjectRelativePath));
				}
				if (lines.Count > 0)
					sec = new Section("SolutionItems", "ProjectSection", "preProject", lines);
			}
			// *** here is the code that I wrote to add website projects ***
			else if (project is WebSiteProject)
			{
				var website = project as WebSiteProject;
				if (_sln.IsUnderSourceControl)
				{
						lines.AddRange(new PropertyLine[]
						{
							new PropertyLine("SccProjectName", "\"SAK\""),
							new PropertyLine("SccAuxPath", "\"SAK\""),
							new PropertyLine("SccLocalPath", "\"SAK\""),
							new PropertyLine("SccProvider", "\"SAK\"")
						});
				}
				if (_sln.SolutionVersion == SolutionFileVersion.V11VS2010)
					lines.Add(new PropertyLine("TargetFrameworkMoniker", "\".NETFramework,Version%3Dv4.0\""));
				else
					lines.Add(new PropertyLine("TargetFramework", "\"3.5\""));
				// add project references
				string projectReferences = "";
				foreach (Project proj in website.ReferencedProjects)
					projectReferences += proj.InstanceGuidSt + "|" + proj.ClassName + ".dll;";
				lines.Add(new PropertyLine("ProjectReferences", "\"" + projectReferences + "\""));
				string debugConf = "Debug.AspNetCompiler.";
				string releaseConf = "Release.AspNetCompiler.";
				string str = debugConf;
				int k = 0;
				while (k < 2)
				{
					// other properties
					lines.AddRange(new PropertyLine[]
					{
						new PropertyLine(str + "VirtualPath", "\"/" + website.Name + "\""),
						new PropertyLine(str + "PhysicalPath", "\"" + website.ObjectRelativePath + "\\\""),
						new PropertyLine(str + "TargetPath", ("\"PrecompiledWeb\\" + website.Name + "\\\"")),
						new PropertyLine(str + "Updateable", "\"true\""),
						new PropertyLine(str + "ForceOverwrite", "\"true\""),
						new PropertyLine(str + "FixedNames", "\"false\""),
						new PropertyLine(str + "Debug", (k == 0 ? "\"True\"" : "\"False\""))
					});
					if (k++ == 0)
						str = releaseConf;
				}
				Random rand = new Random();
				lines.Add(new PropertyLine("VWDPort", "\"" + rand.Next(1111, 65000).ToString() + "\""));
				lines.Add(new PropertyLine("DefaultWebSiteLanguage",
					website.Language == SeptaCodeGenerator.Core.Language.CodeLanguage.CSharp ? "\"Visual C#\"" : "\"Visual Basic\""));
				sec = new Section("WebsiteProperties", "ProjectSection", "preProject", lines);
			}
			var sections = new List<Section>();
			if (sec != null)
				sections.Add(sec);
			return sections;
		}
    }
