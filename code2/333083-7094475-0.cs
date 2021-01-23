    class MyTypeConverter : TypeConverter
    {
        public override bool ConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            try
            {
                return base.ConvertFrom(context, sourceType);
            }
            catch(Exception e)
            { 
                // Process the exception (for example, Log(e)) or Debug.Assert()
                throw;
            }
        }
    }
    // Using the TypeConverter in your class
    class MyClass
    {
        [ReadOnly(false)]
        [PropertyOrder(1)]
        [DisplayName("Property 1")]
        [TypeConverter(typeof(MyTypeConverter))]
        public int Property1
        {
            get;
            set;
        }
    }
