    var resourceProject = Microsoft.Build.Evaluation
                                  .ProjectCollection.GlobalProjectCollection
                                    .LoadedProjects.FirstOrDefault(pr => pr.FullPath == projFilePath);
    
                            if (resourceProject == null)
                                resourceProject = new Microsoft.Build.Evaluation.Project(projFilePath);
                            //add resx file if it doesn't exist in the project
                            if (resourceProject.Items.FirstOrDefault(i => i.EvaluatedInclude == path) == null)
                            {
                                string designerPath = path.Replace(".resx", ".Designer.cs");
                                //Add metadata when the resx file has a designer file
                                resourceProject.AddItem("EmbeddedResource", path);
                                if (withDesigner)
                                {
                                    var projectItem = resourceProject.Items.FirstOrDefault(i => i.EvaluatedInclude == path);
                                    projectItem.SetMetadataValue("Generator", "ResXFileCodeGenerator");
                                    projectItem.SetMetadataValue("LastGenOutput", Path.GetFileName(designerPath));
                                    resourceProject.AddItem("Compile", designerPath);
                                    var designerItem = resourceProject.Items.FirstOrDefault(i => i.EvaluatedInclude == designerPath);
                                    designerItem.SetMetadataValue("AutoGen", "True");
                                    designerItem.SetMetadataValue("DesignTime", "True");
                                    designerItem.SetMetadataValue("DependentUpon", Path.GetFileName(path));
                                }
                                resourceProject.Save();
                            }
