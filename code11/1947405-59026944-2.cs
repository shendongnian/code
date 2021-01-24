    public enum Color
    {
        Red,
        Green,
        Blue,
        White,
        Black,
    }
    public class ExcludeColorAttribute : Attribute
    {
        public Color[] Exclude { get; private set; }
        public ExcludeColorAttribute(params Color[] exclude)
        {
            Exclude = exclude;
        }
    }
    public class ExcludeColorTypeConverter : EnumConverter
    {
        public ExcludeColorTypeConverter() : base(typeof(Color))
        {
        }
        public override StandardValuesCollection GetStandardValues(
            ITypeDescriptorContext context)
        {
            var original = base.GetStandardValues(context);
            var exclude = context.PropertyDescriptor.Attributes
                .OfType<ExcludeColorAttribute>().FirstOrDefault()?.Exclude
                ?? new Color[0];
            var excluded = new StandardValuesCollection(
                original.Cast<Color>().Except(exclude).ToList());
            Values = excluded;
            return excluded;
        }
    }
