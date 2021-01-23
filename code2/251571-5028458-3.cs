    public class ValueElement : ConfigurationElement
    {
        [ConfigurationProperty( "value" )]
        public string Value
        {
            get { return (string)base[ "value" ]; }
            set { base[ "value" ] = value; }
        }
    }
    public class TriggerElement : ConfigurationElement
    {
        [ConfigurationProperty( "name" )]
        public string Name
        {
            get { return (string)base[ "name" ]; }
            set { base[ "name" ] = value; }
        }
        [ConfigurationProperty( "varAlias" )]
        public string VarAlias
        {
            get { return (string)base[ "varAlias" ]; }
            set { base[ "varAlias" ] = value; }
        }
        [ConfigurationProperty( "lower" )]
        public int Lower
        {
            get { return (int)base[ "lower" ]; }
            set { base[ "lower" ] = value; }
        }
        [ConfigurationProperty( "upper" )]
        public int Upper
        {
            get { return (int)base[ "upper" ]; }
            set { base[ "upper" ] = value; }
        }
    }
    [ConfigurationCollection( typeof( TriggerElement ) )]
    public class TriggerElementCollection : ConfigurationElementCollection
    {
        public TriggerElement this[ string name ]
        {
            get { return (TriggerElement)base.BaseGet( name ); }
        }
        public TriggerElement this[ int index ]
        {
            get { return (TriggerElement)base.BaseGet( index ); }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new TriggerElement();
        }
        protected override object GetElementKey( ConfigurationElement element )
        {
            return ( (TriggerElement)element ).Name;
        }
    }
