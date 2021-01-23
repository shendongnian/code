    watcher = new FileSystemWatcher(section["inputDirectory"]);
     foreach (ConfigurationSectionGroup sectionGroup in sectionGroups)
                {
                    if (sectionGroup.Name == "FileCheckerConfigGroup")
                    {
                        foreach (ConfigurationSection configurationSection in sectionGroup.Sections)
                        {
                            //FileChecker filecheck = new FileChecker();
                            //filecheck.ProccessFolders(configurationSection);
                            //FileChecker filecheck = new FileChecker();
                            var section = ConfigurationManager.GetSection(configurationSection.SectionInformation.SectionName) as NameValueCollection;
                            watcher.EnableRaisingEvents = true;
                            watcher.Created += (sender, e) =>
                            {
                                using (var filecheck = new FileChecker())
                                {
                                    filecheck.ProccessFolders(configurationSection);
                                }
                            };                               
                        }
                    }
                }
