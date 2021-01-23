    static Configuration OpenConfiguration() {
        if (HttpContext.Current != null)
            return WebConfigurationManager.OpenWebConfiguration(null);
        return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    }
    static IEnumerable<ConfigurationSectionGroup> GetConfigSectionGroups() {
        var config = OpenConfiguration();
        var stack = new Stack<ConfigurationSectionGroup>();
        stack.Push(config.RootSectionGroup);
        while (stack.Count > 0) {
            var group = stack.Pop();
            yield return group;
            foreach (ConfigurationSectionGroup subGroup in group.SectionGroups) {
                stack.Push(subGroup);
            }
        }
    }
