    using System.Xml.Linq;
    public void ActivatePlugins(string filePath)
    {
        XElement plugins = XElement.Load(filePath);
        foreach(var plugin in plugins.Elements("Plugin"))
        {
            for(int i = 0; i < Components.Count; i++)
            {
                if(Type.GetType(plugin.Value) == Components[i].GetType()) 
                { ((GameCompoent)Components[i]).Enabled = true; }
                break;
            }
        }
    }
