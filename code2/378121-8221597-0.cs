    void Test()
    {
        var serializer = new FixedWidthSerializer<MyClass>();
        var ms = new MemoryStream();
        serializer.Serialize(ms, new MyClass { Age = 30, FirstName = "John", LastName = "Doe"});
        ms.Position = 0;
        var newMyClass = (MyClass)serializer.Deserialize(ms);
    }
    [Serializable]
    private class MyClass
    {
        public String FirstName { get; set; }
        public String LastName;
        public Int32 Age { get; set; }
    }
    public class FixedWidthSerializer<T> : IFormatter
    {
        private readonly FixedWidthFieldDefinition[] _fieldDefinition;
        public FixedWidthSerializer()
            : 
            this(FormatterServices.GetSerializableMembers(typeof(T)).Select(sm=>new FixedWidthFieldDefinition(sm.Name, 100)).ToArray())
        { }
        public FixedWidthSerializer(FixedWidthFieldDefinition[] fieldDefinition)
        {
            if (fieldDefinition == null) throw new ArgumentNullException("fieldDefinition");
            _fieldDefinition = fieldDefinition;
            Context = new StreamingContext(StreamingContextStates.All);            
        }
        public class FixedWidthFieldDefinition
        {
            public String FieldName { get; protected set; }
            public Int32 CharLength { get; protected set; }
            public FixedWidthFieldDefinition(String fieldName, Int32 charLength)
            {
                FieldName = fieldName;
                CharLength = charLength;
            }
        }
        public object Deserialize(Stream serializationStream)
        {
            var streamReader = new StreamReader(serializationStream);
            var textLine = streamReader.ReadLine();
            if (textLine == null)
                throw new SerializationException("Ran out of text!");
            var obj = FormatterServices.GetUninitializedObject(typeof (T));
            var memberDictionary = FormatterServices.GetSerializableMembers(obj.GetType(), Context).ToDictionary(mi => mi.Name);
            var offset = 0;
            foreach (var fieldDef in _fieldDefinition)
            {
                if (offset + fieldDef.CharLength > textLine.Length)
                    throw new SerializationException("Line was too short!");
                // Read the current field and increase the offset
                var fieldStringValue = textLine.Substring(offset, fieldDef.CharLength);
                offset += fieldDef.CharLength;
                MemberInfo memberInfo;
                if (!memberDictionary.TryGetValue(fieldDef.FieldName, out memberInfo))
                    throw new SerializationException("You asked for the member '" + fieldDef.FieldName + "', but it doesn't exist on type '" + typeof (T) + "'");
                var memberAsField = memberInfo as FieldInfo;
                if (memberAsField != null)
                    memberAsField.SetValue(obj, Convert.ChangeType(fieldStringValue.TrimEnd(), memberAsField.FieldType));
                else
                    throw new SerializationException("I don't know what to make of the property '" + fieldDef.FieldName + "'");
            }
            return obj;
        }
        public void Serialize(Stream serializationStream, object graph)
        {
            var serializableMembers = FormatterServices.GetSerializableMembers(graph.GetType());
            var membersToSerialize = _fieldDefinition.Select(fd => serializableMembers.First(sm => sm.Name == fd.FieldName)).ToArray();
            var objectData = FormatterServices.GetObjectData(graph, membersToSerialize);
            var sb = new StringBuilder(_fieldDefinition.Sum(fd => fd.CharLength));
            for (var i = 0; i < _fieldDefinition.Length; i++)
                sb.Append(((String) Convert.ChangeType(objectData[i], typeof (String))).PadRight(_fieldDefinition[i].CharLength), 0, _fieldDefinition[i].CharLength);
            var sw = new StreamWriter(serializationStream);
            sw.WriteLine(sb.ToString());
            sw.Flush();
        }
        public ISurrogateSelector SurrogateSelector { get; set; }
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
    }
