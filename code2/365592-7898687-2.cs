    public static class XmlExtensions
    {
        public static string ToXml<T>(this T instance)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, instance);
            return stringWriter.ToString();
        }
    }
    public static string CreateXMLforEngineersByLinqMyWay(List<Engineers> lst)
    {
        return string.Format("<Engineers>{0}</Engineers>"
            , string.Join("",
                lst.Select(s => s.ToXml()) // Might have to put `.ToArray()` here
                )
            );
    }
