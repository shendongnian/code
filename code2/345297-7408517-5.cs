              public interface IPluginInterface
              {
                /// <summary>
                /// Defines the name for the plugin to use.
                /// </summary>
                /// <value>The name.</value>
                String name { get; }
                /// <summary>
                /// Defines the version string for the plugin to use.
                /// </summary>
                /// <value>The version.</value>
                String version { get; }
                /// <summary>
                /// Defines the name of the author of the plugin.
                /// </summary>
                /// <value>The author.</value>
                String author { get; }
                /// <summary>
                /// Defines the name of the root of xml packets destined
                /// the plugin to recognise as it's own.
                /// </summary>
                /// <value>The name of the XML root.</value>
                String xmlRootName { get; }
                /// <summary>
                /// Defines the method that is used by the host service shell to pass request data
                /// in XML to the plugin for processing.
                /// </summary>
                /// <param name="XMLData">String containing XML data containing the request.</param>
                /// <returns>String holding XML data containing the reply to the request.</returns>
                String processRequest(String XMLData);
                /// <summary>
                /// Defines the method used at shell startup to provide any one time initialisation
                /// the client will call this once, and once only passing to it a host interface pointing to itself
                /// that the plug shall use when calling methods in the IPluginHost interface.
                /// </summary>
                /// <param name="theHost">The IPluginHost interface relating to the parent shell program.</param>
                /// <returns><c>true</c> if startup was successfull, otherwise <c>false</c></returns>
                Boolean startup(IPluginHost theHost);
                /// <summary>
                /// Called by the shell service at shutdown to allow to close any resources used.
                /// </summary>
                /// <returns><c>true</c> if shutdown was successfull, otherwise <c>false</c></returns>
                Boolean shutdown();
              }
