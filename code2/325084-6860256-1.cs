    public class LampViewModel
    {
       public string SomeProperty {get;set}
       public LampSpecialProperties SpecialProperties {get;set;}
    }
    
    public abstract class LampSpecialProperties
    { }
    
    public class SomeConcreteLampSpecialProperties : LampSpecialProperties
    {
         public string BrightnessLevel {get;set;}
    }
