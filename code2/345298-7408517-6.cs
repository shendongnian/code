                public interface IPluginHost
                {
                  /// <summary>
                  /// Defines a method to be called by plugins of the client in order that they can 
                  /// inform the service of any events it may need to be aware of.
                  /// </summary>
                  /// <param name="xmlData">String containing XML data the shell should act on.</param>
                  void eventCallback(String xmlData);
                }
