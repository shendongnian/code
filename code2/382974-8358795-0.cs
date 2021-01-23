        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form {Controls = {
                new PropertyGrid {SelectedObject = new SomeType
                {
                    Content = new byte[] {0,1,2,3,4,5}                                               
                }, Dock = DockStyle.Fill}
            }});
        }
        public class SomeType
        {
            private byte[] _content;
            [TypeConverter(typeof(HexConverter))]
            public byte[] Content
            {
                get
                {
                    return _content;
                }
                internal set
                {
                    _content = value;
                }
            }
        }
        class HexConverter : TypeConverter
        {
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                if(destinationType == typeof(string))
                {
                    if (value == null) return "";
                    byte[] raw = (byte[]) value;
                    var sb = new StringBuilder(2*raw.Length);
                    for (int i = 0; i < raw.Length; i++) sb.Append(raw[i].ToString("x2"));
                    return sb.ToString();
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
