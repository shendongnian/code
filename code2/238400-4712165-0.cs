    foreach (ConfigurationSectionGroup sectionGroup in sectionGroups)
    {
        if (sectionGroup.Name == "FileCheckerConfigGroup")
        {
            foreach (ConfigurationSection configurationSection in sectionGroup.Sections)
            {
                var section = ConfigurationManager.GetSection(configurationSection.SectionInformation.SectionName) as NameValueCollection;
                var watcher = new FileSystemWatcher(section["inputDirectory"]);
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
