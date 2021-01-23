    public class MyConfigurationGroup : ConfigurationSectionGroup
    {
        [ConfigurationProperty( "emailNotification" )]
        public EmailNotificationSection EmailNotification
        {
            get { return (EmailNotificationSection)base.Sections[ "emailNotification" ]; }
        }
    }
