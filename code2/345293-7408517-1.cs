    private Boolean loadPlugin(String pluginFile)
    {
      // Default to a successfull result, this will be changed if needed
      Boolean result = true;
      Boolean interfaceFound = false;
      // Default plugin type is unknown
      pluginType plType = pluginType.unknown;
      // Check the file still exists
      if (!File.Exists(pluginFile))
      {
        result = false;
        return result;
      }
      // Standard try/catch block
      try
      {
        // Attempt to load the assembly using .NET reflection
        Assembly asm = Assembly.LoadFile(pluginFile);
        // loop over a list of types found in the assembly
        foreach (Type asmType in asm.GetTypes())
        {
          // If it's a standard abstract, IE Just the interface but no code, ignore it
          // and continue onto the next iteration of the loop
          if (asmType.IsAbstract) continue;
          // Check if the found interface is of the same type as our plugin interface specification
          if (asmType.GetInterface("IPluginInterface") != null)
          {
            // Set our result to true
            result = true;
            // If we've found our plugin interface, cast the type to our plugin interface and
            // attempt to activate an instance of it.
            IPluginInterface plugin = (IPluginInterface)Activator.CreateInstance(asmType);
            // If we managed to create an instance, then attempt to get the plugin type
            if (plugin != null)
            {
              // Get a list of custom attributes from the assembly
              object[] attributes = asmType.GetCustomAttributes(typeof(pluginTypeAttribute), true);
              // If custom attributes are found....
              if (attributes.Length > 0)
              {
                // Loop over them until we cast one to our plug in type
                foreach (pluginTypeAttribute pta in attributes)
                  plType = pta.type;
              }// End if attributes present
              // Finally add our new plugin to the list of plugins avvailable for use
              pluginList.Add(new pluginListItem() { thePlugin = plugin, theType = plType });
              plugin.startup(this);
              result = true;
              interfaceFound = true;
            }// End if plugin != null
            else
            {
              // If plugin could not be activated, set result to false.
              result = false;
            }
          }// End if interface type not plugin
          else
          {
            // If type is not our plugin interface, set the result to false.
            result = false;
          }
        }// End for each type in assembly
      }
      catch (Exception ex)
      {
        // Take no action if loading the plugin causes a fault, we simply
        // just don't load it.
        writeToLogFile("Exception occured while loading plugin DLL " + ex.Message);
        result = false;
      }
      if (interfaceFound)
        result = true;
      return result;
    }// End loadDriverPlugin
