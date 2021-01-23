            [AttributeUsage(AttributeTargets.Class)]
            public sealed class pluginTypeAttribute : Attribute
            {
              private pluginType _type;
              /// <summary>
              /// Initializes a new instance of the attribute.
              /// </summary>
              /// <param name="T">Value from the plugin types enumeration.</param>
              public pluginTypeAttribute(pluginType T) { _type = T; }
              /// <summary>
              /// Publicly accessible read only property field to get the value of the type.
              /// </summary>
              /// <value>The plugin type assigned to the attribute.</value>
              public pluginType type { get { return _type; } }
            }
