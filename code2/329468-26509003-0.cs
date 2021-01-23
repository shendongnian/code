    public static class XDoncumentExtentions
    {
        private static string DefaultNamespace = "{http://schemas.openxmlformats.org/spreadsheetml/2006/main}";
        public static IEnumerable<XElement> DescendantsSimple(this XContainer me, string simpleName)
        {
            return me.Descendants(string.Format("{0}{1}", DefaultNamespace, simpleName));
        }
        public static IEnumerable<XElement> ElementsSimple(this XContainer me, string simpleName)
        {
            return me.Elements(string.Format("{0}{1}", DefaultNamespace, simpleName));
        }
        public static XElement ElementSimple(this XContainer me, string simpleName)
        {
            return me.Element(string.Format("{0}{1}", DefaultNamespace, simpleName));
        }
    }
