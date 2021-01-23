    public class Parent
    {
        [JsonConverter(typeof(InterfaceConverter<IChildModel, ChildModel>))]
        IChildModel Child { get; set; }
    }
