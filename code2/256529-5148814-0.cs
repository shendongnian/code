        public void Parse()
        {
            //XElement xElement = blah...
            var elements = xElement.Elements("Effects").Elements("Effect");
            var converted = elements.Select(ConvertToEffect);
        }
        private static Effect ConvertToEffect(XElement e)
        {
            var value = ConvertEnum((string) e.Elements("Type").FirstOrDefault());
            var option = GetOption(e.Elements("Options"));
            return new Effect(value, option);
        }
 
        private static EffectType ConvertEnum(string value)
        {
            return (EffectType)Enum.Parse(typeof(EffectType), value);
        }
        private static IEnumerable<object> GetOption(IEnumerable<XElement> e)
        {
            var any = e.Elements("Options").Any();
            if (any)
            {
                return e.Elements("Options").Select(o => (object) o.Elements("Option").Select(n => n.Value).First());
            }
            return null;
        }
