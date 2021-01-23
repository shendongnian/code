Your proposed Merger method could possibly look like this:
    public class Merger
    {
        public static object Merge(object copyFrom, object copyTo)
        { 
            var xmlContent = MyXMLSerializationMethod(copyFrom);
            MyXMLDeserializationMethod(xmlContent, typeof(copyTo), out copyTo);
            return copyTo;
        }
    }
