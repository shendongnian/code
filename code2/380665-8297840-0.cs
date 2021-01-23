    public class EnumModelBinderAttribute : CustomModelBinderAttribute
    {
        public string Source { get; set; }
        public Type EnumType { get; set; }
        public override IModelBinder GetBinder()
        {
            Type genericBinderType = typeof(EnumBinder<>);
            Type binderType = genericBinderType.MakeGenericType(EnumType);
            return (IModelBinder) Activator.CreateInstance(binderType, this.Source);
        }
    }
