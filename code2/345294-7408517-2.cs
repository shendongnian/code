        public struct pluginListItem
        {
          /// <summary>
          /// Interface pointer to the loaded plugin, use this to gain access to the plugins
          /// methods and properties.
          /// </summary>
          public IPluginInterface thePlugin;
          /// <summary>
          /// pluginType value from the valid enumerated values of plugin types defined in
          /// the plugin interface specification, use this to determine the type of hardware
          /// this plugin driver represents.
          /// </summary>
          public pluginType theType;
        }
