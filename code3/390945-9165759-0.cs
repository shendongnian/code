    public class DefaultValueConvention : MongoDB.Bson.Serialization.Conventions.IDefaultValueConvention
    {
        public object GetDefaultValue(MemberInfo memberInfo)
        {
            var type = memberInfo.MemberType == MemberTypes.Property
                           ? ((PropertyInfo) memberInfo).PropertyType
                           : ((FieldInfo) memberInfo).FieldType;
            if (type.IsSubclassOf(typeof(ObjectId)))
                return ObjectId.GenerateNewId();
            else
                return null;
        }
    }
