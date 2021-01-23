                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using pluginInterfaces;
                using System.IO;
                using System.Xml.Linq;
                namespace pluginSkeleton
                {
                  /// <summary>
                  /// Main plugin class, the actual class name can be anything you like, but it MUST
                  /// inherit IPluginInterface in order that the shell accepts it as a hardware driver
                  /// module. The [PluginType] line is the custom attribute as defined in pluginInterfaces
                  /// used to define this plugins purpose to the shell app.
                  /// </summary>
                  [pluginType(pluginType.printer)]
                  public class thePlugin : IPluginInterface
                  {
                    private String _name = "Printer Plugin"; // Plugins name
                    private String _version = "V1.0";        // Plugins version
                    private String _author = "Shawty";       // Plugins author
                    private String _xmlRootName = "printer"; // Plugins XML root node
                    public string name { get { return _name; } }
                    public string version { get { return _version; } }
                    public string author { get { return _author; } }
                    public string xmlRootName { get { return _xmlRootName; } }
                    public string processRequest(string XMLData)
                    {
                      XDocument request = XDocument.Parse(XMLData);
                      // Use Linq here to pick apart the XML data and isolate anything in our root name space
                      // this will isolate any XML in the tags  <printer>...</printer>
                      var myData = from data in request.Elements(this._xmlRootName)
                                   select data;
                      // Dummy return, just return the data passed to us, format of this message must be passed
                      // back acording to Shell XML communication specification.
                      return request.ToString();
                    }
                    public bool startup(IPluginHost theHost)
                    {
                      bool result = true;
                      try
                      {
                        // Implement any startup code here
                      }
                      catch (Exception ex)
                      {
                        result = false;
                      }
                      return result;
                    }
                    public bool shutdown()
                    {
                      bool result = true;
                      try
                      {
                        // Implement any shutdown code here
                      }
                      catch (Exception ex)
                      {
                        result = false;
                      }
                      return result;
                    }
                  }// End class
                }// End namespace
