     /// <see cref="https://stackoverflow.com/questions/4185816/how-to-pass-an-unknown-type-between-two-net-appdomains"/>
        [Serializable]
        public class PluginProxy : MarshalByRefObject, ICustomPlugin
        {
            private ICustomPlugin _hostedPlugin;            
    
            /// <summary>
            /// Parameterless constructor for deserialization 
            /// </summary>
            public PluginProxy()
            {             
            }
    
            ~PluginProxy()
            {
                Debug.WriteLine("DESTRUCTOR ~PluginProxy");
            }
    
            /// <summary>
            /// Constructor reserved from real Plugin type
            /// </summary>
            /// <param name="name"></param>
            public PluginProxy(ICustomPlugin hostedPlugin)
            {
                _hostedPlugin = hostedPlugin;
            }
    
            public PluginName Name => _hostedPlugin.Name;
    
            public PluginResult Execute(PluginParameters parameters, PluginQuery query)
            {
                return(_hostedPlugin.Execute(parameters, query));
            }
        }
