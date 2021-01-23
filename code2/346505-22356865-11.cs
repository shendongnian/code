    public class KoordConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string text = value as string;
            if (text == null)
            {
                return base.ConvertFrom(context, culture, value);
            }
            string text2 = text.Trim();
            if (text2.Length == 0)
            {
                return null;
            }
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture;
            }
            char c = culture.TextInfo.ListSeparator[0];
            string[] array = text2.Split(new char[]
			{
				c
			});
            int[] array2 = new int[array.Length];
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = (int)converter.ConvertFromString(context, culture, array[i]);
            }
            if (array2.Length == 3)
            {
                return new Koord(array2[0], array2[1], array2[2]);
            }
            throw new ArgumentException("TextParseFailedFormat");
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if (value is Koord)
            {
                if (destinationType == typeof(string))
                {
                    Koord Koord = (Koord)value;
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }
                    string separator = culture.TextInfo.ListSeparator + " ";
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
                    string[] array = new string[3];
                    int num = 0;
                    array[num++] = converter.ConvertToString(context, culture, Koord.X);
                    array[num++] = converter.ConvertToString(context, culture, Koord.Y);
                    array[num++] = converter.ConvertToString(context, culture, Koord.Z);
                    return string.Join(separator, array);
                }
                if (destinationType == typeof(InstanceDescriptor))
                {
                    Koord Koord2 = (Koord)value;
                    ConstructorInfo constructor = typeof(Koord).GetConstructor(new Type[]
					{
						typeof(double),
						typeof(double),
						typeof(double)
					});
                    if (constructor != null)
                    {
                        return new InstanceDescriptor(constructor, new object[]
						{
							Koord2.X,
							Koord2.Y,
							Koord2.Z
						});
                    }
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }
            object obj = propertyValues["X"];
            object obj2 = propertyValues["Y"];
            object obj3 = propertyValues["Z"];
            if (obj == null || obj2 == null || obj3 == null || !(obj is double) || !(obj2 is double) || !(obj3 is double))
            {
                throw new ArgumentException("PropertyValueInvalidEntry");
            }
            return new Koord((double)obj, (double)obj2, (double)obj3);
        }
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(Koord), attributes);
            return properties.Sort(new string[]
			{
				"X",
				"Y",
                "Z"
			});
        }
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
    
