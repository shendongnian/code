    public class ServiceConfigurationSection : ConfigurationSection
    {
       [ConfigurationProperty("Services", IsDefaultCollection = false)]
       [ConfigurationCollection(typeof(ServiceCollection),
           AddItemName = "add",
           ClearItemsName = "clear",
           RemoveItemName = "remove")]
       public ServiceCollection Services
       {
          get
          {
             return (ServiceCollection)base["Services"];
          }
       }
    }
