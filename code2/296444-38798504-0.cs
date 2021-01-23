    class EnumToObjectArray : MarkupExtension
    {
        public BindingBase SourceEnum { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            DependencyObject targetObject;
            DependencyProperty targetProperty;
            if (target != null && target.TargetObject is DependencyObject && target.TargetProperty is DependencyProperty)
            {
                targetObject = (DependencyObject)target.TargetObject;
                targetProperty = (DependencyProperty)target.TargetProperty;
            }
            else
            {
                return this;
            }
            BindingOperations.SetBinding(targetObject, EnumToObjectArray.SourceEnumBindingSinkProperty, SourceEnum);
            var type = targetObject.GetValue(SourceEnumBindingSinkProperty).GetType();
            if (type.BaseType != typeof(System.Enum)) return this;
            return Enum.GetValues(type)
                .Cast<Enum>()
                .Select(e => new { Value=e, Name = e.ToString(), DisplayName = Description(e) });
        }
        private static DependencyProperty SourceEnumBindingSinkProperty = DependencyProperty.RegisterAttached("SourceEnumBindingSink", typeof(Enum)
                           , typeof(EnumToObjectArray), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
        /// <summary>
        /// Extension method which returns the string specified in the Description attribute, if any.  Oherwise, name is returned.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns></returns>
        public static string Description(Enum value)
        {
            var attrs = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attrs.Any())
                return (attrs.First() as DescriptionAttribute).Description;
            //Fallback
            return value.ToString().Replace("_", " ");
        }
    }
