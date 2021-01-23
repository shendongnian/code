    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var states = new string[] { "null", "empty", "noparse", "value" };
                var xml = "<root>";
                xml += "<topLevel><long>-13451245234</long><string>hello world</string><datetime>1/1/2012 8:00AM</datetime></topLevel>";
                xml += "<topLevel><long>4563264643</long><string>lipsum</string><datetime></datetime></topLevel>";
                xml += "<topLevel><string>hello world</string><datetime>1/1/2012 8:00AM</datetime></topLevel>";
                xml += "</root>";
            IEnumerable<Element> elements =
                from topLevelElement in XElement.Parse(xml).Elements("topLevel")
                select new Element
                           {
                               LongElement = ParseValue(topLevelElement, "long"),
                               DateTimeElement = ParseValue(topLevelElement, "datetime"),
                               StringElement = ParseValue(topLevelElement, "string"),
                           };
            var idx = 0;
            elements.All(e =>
            {
                Console.WriteLine("---- ELEMENT #{0} -----",idx++);
                Console.WriteLine("[long]     State: {0}\tValue:{1}\tType:{2}", states[e.LongElement.Key], e.LongElement.Value, (e.LongElement.Value).GetType());
                Console.WriteLine("[datetime] State: {0}\tValue:{1}\tType:{2}", states[e.DateTimeElement.Key], e.DateTimeElement.Value, (e.DateTimeElement.Value).GetType());
                Console.WriteLine("[string]   State: {0}\tValue:{1}\tType:{2}", states[e.StringElement.Key], e.StringElement.Value, (e.StringElement.Value).GetType());
                
                
                return true;
            });
        }
        private static dynamic ParseValue(XElement parent, String propname)
        {
            var prop = parent.Element(propname);
            dynamic val = null;
            byte state = 255;
            if (prop == null) state = 0;
            else if (string.IsNullOrEmpty(prop.Value)) state = 1;
            if (state < 255) return GetKVP(propname, state, GetDefaultValue(propname));
            switch (propname)
            {
                case "string":
                    state = 3;
                    val =  prop.Value;
                    break;
                case "long":
                    Int64 longvalue;
                    if (Int64.TryParse(prop.Value, out longvalue)) { state = 3; val = longvalue; }
                    else state = 2;
                    break;
                case "datetime":
                    DateTime datetimevalue;
                    if (DateTime.TryParse(prop.Value, out datetimevalue)) { state = 3; val = datetimevalue; }
                    else state = 2;
                    break;
                default:
                    val = GetDefaultValue(propname);
                    break;
            }
            return GetKVP(propname,state,val);
        }
        private static dynamic GetKVP(string propname, byte state, object val)
        {
            if (propname == "long") return new KeyValuePair<byte, Int64>(state, (Int64)val);
            if (propname == "datetime") return new KeyValuePair<byte, DateTime>(state, (DateTime)val);
            if (propname == "string") return new KeyValuePair<byte, String>(state, (String)val);
            return null;
        }
        private static dynamic GetDefaultValue(string propname)
        {
            if (propname == "long") return long.MinValue;
            if (propname == "datetime") return DateTime.MinValue;
            if (propname == "string") return null;
            return null;
        }
        #region Nested type: Element
        public struct Element
        {
            // States stored as byte, 0 = null, 1= empty, 2 = has a value
            public KeyValuePair<byte,Int64> LongElement { get; set; }
            public KeyValuePair<byte,String> StringElement { get; set; }
            public KeyValuePair<byte,DateTime> DateTimeElement { get; set; }
        }
        #endregion
    }
    }
