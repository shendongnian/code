    public class Input
    {
         public InputType InputType { get; set; }
         public Temperature ProbeTemperature { get; set; }
         public Temperature RackTemperature { get; set; }
    }
    public class Temperature
    {
         public string Parameter { get; set; }
         public string Label { get; set; }
    }
    public enum InputType
    {
         Digital,
         Analog
    }
