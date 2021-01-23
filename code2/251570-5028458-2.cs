    public class EmailNotificationSection : ConfigurationSection
    {
        [ConfigurationProperty( "to" )]
        public ValueElement To
        {
            get { return (ValueElement)base[ "to" ]; }
        }
        [ConfigurationProperty( "from" )]
        public ValueElement From
        {
            get { return (ValueElement)base[ "from" ]; }
        }
        [ConfigurationProperty( "subject" )]
        public ValueElement Subject
        {
            get { return (ValueElement)base[ "subject" ]; }
        }
        [ConfigurationProperty( "smtpHost" )]
        public ValueElement SmtpHost
        {
            get { return (ValueElement)base[ "smtpHost" ]; }
        }
        [ConfigurationProperty( "triggers" )]
        public TriggerElementCollection Triggers
        {
            get { return (TriggerElementCollection)base[ "triggers" ]; }
        }
    }
