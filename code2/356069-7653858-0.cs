    [AttributeUsageAttribute(AttributeTargets.Class|
      AttributeTargets.Struct|
      AttributeTargets.Enum|
      AttributeTargets.Delegate, 
      Inherited = false)] // <- Note this!
    [ComVisibleAttribute(true)]
    public sealed class SerializableAttribute : Attribute
