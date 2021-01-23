    public class  DispatcherConfigurationSection: ConfigurationSection
    {
        [ConfigurationProperty("maxRetry", IsRequired = false, DefaultValue = 5)]
        public int MaxRetry
        {
            get
            {
                return (int)this["maxRetry"];
            }
            set
            {
                this["maxRetry"] = value;
            }
        }
        [ConfigurationProperty("eventsDispatches", IsRequired = true)]
        [ConfigurationCollection(typeof(EventsDispatchConfigurationElement), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        public GenericConfigurationElementCollection<EventsDispatchConfigurationElement> EventsDispatches
        {
            get { return (GenericConfigurationElementCollection<EventsDispatchConfigurationElement>)this["eventsDispatches"]; }
        }
    }
