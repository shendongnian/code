    foreach (ConfigurationSectionGroup sectionGroup in sectionGroups)
    {
        if (sectionGroup.Name == "FileCheckerConfigGroup")
        {
            foreach(ConfigurationSection configurationSection in sectionGroup.Sections)
            {
                //FileChecker filecheck = new FileChecker();
                //filecheck.ProccessFolders(configurationSection);
                //FileChecker filecheck = new FileChecker();
                var localConfigurationSectionCopy = configurationSection;
                var section = ConfigurationManager.GetSection(configurationSection.SectionInformation.SectionName) as NameValueCollection;
                watcher = new FileSystemWatcher(section["inputDirectory"]);
                watcher.EnableRaisingEvents = true;
                watcher.Created += (sender, e) =>
                {
                    using (var filecheck = new FileChecker())
                    {
                        filecheck.ProccessFolders(localConfigurationSectionCopy);
                    }
                };                               
            }
        }
    }
