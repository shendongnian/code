    protected override string Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the input arguments.
            string assemblyInfoFileMask = context.GetValue(AssemblyInfoFileMask);
            IBuildDetail buildDetail = context.GetValue(BuildDetail);
    
            var workspace = buildDetail.BuildDefinition.Workspace;
            var versionControl = buildDetail.BuildServer.TeamProjectCollection.GetService<VersionControlServer>();
    
            Regex regex = new Regex(AttributeKey + VersionRegex);
    
            // Iterate of the folder mappings in the workspace and find the AssemblyInfo files 
            // that match the mask.
            foreach (var folder in workspace.Mappings)
            {
                string path = Path.Combine(folder.ServerItem, assemblyInfoFileMask);
                context.TrackBuildMessage(string.Format("Checking for file: {0}", path));
                ItemSet itemSet = versionControl.GetItems(path, RecursionType.Full);
    
                foreach (Item item in itemSet.Items)
                {
                    context.TrackBuildMessage(string.Format("Download {0}", item.ServerItem));
                    string localFile = Path.GetTempFileName();
    
                    try
                    {
                        // Download the file and try to extract the version.
                        item.DownloadFile(localFile);
                        string text = File.ReadAllText(localFile);
                        Match match = regex.Match(text);
    
                        if (match.Success)
                        {
                            string versionNumber = match.Value.Substring(AttributeKey.Length + 2, match.Value.Length - AttributeKey.Length - 4);
                            Version version = new Version(versionNumber);
                            Version newVersion = new Version(version.Major, version.Minor, version.Build + 1, version.Revision);
    
                            context.TrackBuildMessage(string.Format("Version found {0}", newVersion));
    
                            return newVersion.ToString();
                        }
                    }
                    finally
                    {
                        File.Delete(localFile);
                    }
                }
            }
    
            return null;
        }
