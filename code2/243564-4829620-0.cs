    /// <summary>
            /// Determines and returns the name of the XmlElement that should represent instances of the given type
            /// in an XML stream.
            /// </summary>
            /// <param name="serializedObjectType"></param>
            /// <returns></returns>        
            [SuppressMessage ("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
            public static string GetRootNodeElementNameForType( Type serializedObjectType )
            {
                // Determine if the Type contains an XmlRoot Attribute.  If so, the XmlRoot attribute should contain
                // the name of the element-name for this type.
                // Otherwise, the name of the type should 've been used for serializing objects of this type.
                XmlRootAttribute theAttrib = Attribute.GetCustomAttribute (serializedObjectType, typeof (XmlRootAttribute)) as XmlRootAttribute;
    
                if( theAttrib != null )
                {
                    if( String.IsNullOrEmpty (theAttrib.ElementName) == false )
                    {
                        return theAttrib.ElementName;
                    }
                    else
                    {
                        return serializedObjectType.Name;
                    }
                }
                else
                {
                    return serializedObjectType.Name;
                }
            }
