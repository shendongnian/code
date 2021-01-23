    public class DeviceTypeEditModel
    {
        int ID { get; set; }
        String Type { get; set; }
        String Description { get; set; } 
        EntityCollection<AttributeDefinition> AttributeDefinitions { get; set; }
        AttributeDefinition AttributeDefinition { get; set;}
    }
