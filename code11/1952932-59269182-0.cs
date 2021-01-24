class MyClass
{
   [JsonPropert("myProperty")]
   public MyChildClass MyProperty {get; set;}
   [JsonProperty("myNewProperty")] // -> Remember, case matters.
   public MyNewChildClass MyNewProperty {get; set;}
}
When you deserialize the class, add a check to see which is not null and work with that (different methods for each i guess). This should help you keep the breaking change to a minimum.
