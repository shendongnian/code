    public class StackOverflow_6100587_751090
    {
        public class MyType
        {
            public MyTypeWithDates d1;
            public MyTypeWithDates d2;
        }
        public class MyTypeWithDates
        {
            public DateTime Start;
            public DateTime End;
        }
        public class MySurrogate : IDataContractSurrogate
        {
            public object GetCustomDataToExport(Type clrType, Type dataContractType)
            {
                throw new NotImplementedException();
            }
            public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
            {
                throw new NotImplementedException();
            }
            public Type GetDataContractType(Type type)
            {
                return type;
            }
            public object GetDeserializedObject(object obj, Type targetType)
            {
                return obj;
            }
            public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
            {
            }
            public object GetObjectToSerialize(object obj, Type targetType)
            {
                return ReplaceLocalDateWithUTC(obj);
            }
            public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
            {
                throw new NotImplementedException();
            }
            public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
            {
                throw new NotImplementedException();
            }
            private object ReplaceLocalDateWithUTC(object obj)
            {
                if (obj == null) return null;
                Type objType = obj.GetType();
                foreach (var field in objType.GetFields())
                {
                    if (field.FieldType == typeof(DateTime))
                    {
                        DateTime fieldValue = (DateTime)field.GetValue(obj);
                        if (fieldValue.Kind != DateTimeKind.Utc)
                        {
                            field.SetValue(obj, fieldValue.ToUniversalTime());
                        }
                    }
                }
                return obj;
            }
        }
        public static void Test()
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(MyType), null, int.MaxValue, true, new MySurrogate(), false);
            MyType t = new MyType
            {
                d1 = new MyTypeWithDates { Start = DateTime.Now, End = DateTime.Now.AddMinutes(1) },
                d2 = new MyTypeWithDates { Start = DateTime.Now.AddHours(1), End = DateTime.Now.AddHours(2) },
            };
            dcjs.WriteObject(ms, t);
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
    }
