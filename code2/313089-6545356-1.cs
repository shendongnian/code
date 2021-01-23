    [ProtoContract]
    public class Foo
    {
        public XmlDocument Bar { get; set; }
        [ProtoMember(1)]
        private string BarSerialized {
            get { return Bar == null ? null : Bar.OuterXml; }
            set {
                if (value == null) { Bar = null; }
                else {
                    var tmp = new XmlDocument();
                    tmp.LoadXml(value);
                    Bar = tmp;
                }
            }
        }
    }
