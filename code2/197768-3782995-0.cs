    internal class MemberConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context,
      Type sourceType)
        {
            if (sourceType == typeof(Dictionary<string, object>))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context,
      CultureInfo culture, object value)
        {
            if (value is Dictionary<string, object>)
            {
                Member member = new Member();
                Dictionary<string, object> d = (Dictionary<string, object>)value;
                if (d.ContainsKey("fName")) { member.fName = Convert.ToString(d["fName"]); };
                if (d.ContainsKey("lName")) { member.lName = Convert.ToString(d["lName"]); };
                if (d.ContainsKey("email")) { member.email = Convert.ToString(d["email"]); };
                return member;
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context,
      CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(Dictionary<string, object>))
            {
                Member member = (Member)value;
                Dictionary<string, object> d = new Dictionary<string, object>();
                d.Add("fName", member.fName);
                d.Add("lName", member.lName);
                d.Add("email", member.email);
                return d;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    [TypeConverter(typeof(MemberConverter))]
    internal class Member
    {
        public string fName;
        public string lName;
        public string email;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dictionary<string, object> {
               {"fName", "John"},
               {"lName", "Doe"},
               {"email", "john@doe.net"}
            };
            Member m = (Member)TypeDescriptor.GetConverter(typeof(Member)).ConvertFrom(d);
            Debugger.Break();
        }
    }
}
