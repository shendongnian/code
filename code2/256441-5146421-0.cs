    [DateOnly]
    public DateTime Foo {get;set;}
    ...
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple=false,Inherited=true)]
    public class DateOnlyAttribute : Attribute {}
