    public class CustomDateTimeTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return DateTime.ParseExact(value.ToString(), "yyyy-MM-dd HH-mm-ss", culture);
        }
    }
    [TypeConverter(typeof(CustomDateTimeTypeConverter))]
    struct AdvancedDateTime
    {
    }
    [TestFixture]
    public class DateTime
    {
        [Test]
        public void TypeConvert_StrangeFormat_ConvertsWithoutProblem()
        {
            string datetime = "2011-04-21 23-12-13";
            TypeConverter converter = TypeDescriptor.GetConverter( typeof (AdvancedDateTime) );
            var convertedFromString = converter.ConvertFromString(datetime);
            Assert.AreEqual(new DateTime(2011,4,21, 23,12,13), convertedFromString);
        }
    }
