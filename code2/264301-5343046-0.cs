    using System;
    using System.Collections.Specialized;
    using System.IO;
    using System.Reflection;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    using PSSpecClassLibrary.Attributes;
    using PSSpecClassLibrary.Sizing.Loads;
    using PSSpecClassLibrary.Utilities;
    
    namespace PSSpecClassLibrary.Sizing
    {
        /// <summary>
        /// Class to represent a step in a sizing project.
        /// </summary>
        [Serializable]
        public class Step : PSSpecObject
        {
            #region Fields
    
            private int m_intVoltageDip;
            private StepList m_stepList;
            private LoadList m_loads;
    
            #endregion
    
            #region Properties
    
            /// <summary>
            /// Returns an XmlSchemaSet for this object type.
            /// </summary>
            [XmlIgnore]
            public static XmlSchemaSet XmlSchemaSet
            {
                get
                {
                    try
                    {
                        XmlSchemaSet xmlSchemaSet = new XmlSchemaSet();
    
                        using (Stream stream = Assembly.GetAssembly(typeof(Step)).GetManifestResourceStream("PSSpecClassLibrary.Sizing.Step.xsd"))
                        {
                            xmlSchemaSet.Add(XmlSchema.Read(stream, XmlSchemaReadValidationCallBack));
                        }
    
                        using (Stream stream = Assembly.GetAssembly(typeof(Step)).GetManifestResourceStream("PSSpecClassLibrary.Guid.xsd"))
                        {
                            xmlSchemaSet.Add(XmlSchema.Read(stream, XmlSchemaReadValidationCallBack));
                        }
    
                        return xmlSchemaSet;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
    
            /// <summary>
            /// The Step Name
            /// </summary>
            [XmlElement(Order = 1)]
            public override string Name
            {
                get
                {
                    return base.Name;
                }
                set
                {
                    base.Name = value;
                }
            }
    
            /// <summary>
            /// Step Voltage Dip
            /// </summary>
            [XmlElement(Order = 2)]
            public int VoltageDip
            {
                get
                {
                    return m_intVoltageDip;
                }
                set
                {
                    m_intVoltageDip = value;
                }
            }
    
            /// <summary>
            /// Step Loads Collection
            /// </summary>
            [XmlElement(Order = 3)]
            public LoadList Loads
            {
                get
                {
                    return m_loads;
                }
                set
                {
                    if (m_loads != value)
                    {
                        if (m_loads != null)
                            m_loads.CollectionChanged -= LoadsChanged;
                        if (value != null)
                        {
                            value.CollectionChanged -= LoadsChanged;
                            value.CollectionChanged += LoadsChanged;
                        }
                    }
                    m_loads = value;
                }
            }
    
            #endregion
    
            #region Methods
    
            /// <summary>
            /// Creates an instance of the class.
            /// </summary>
            public Step()
            {
                m_loads = new LoadList(this);
            }
    
            #endregion
        }
    }
