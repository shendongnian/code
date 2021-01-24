    public class EnumValueDataContractSurrogate : IDataContractSurrogate
    {
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (targetType.IsEnum && !Enum.IsDefined(targetType, obj))
            {
                return EnumExtensions.ChangeToUnderlyingType(targetType, obj);
            }
            return obj;
        }
        
        public object GetDeserializedObject(object obj, Type targetType)
        {
            return obj;
        }
    }
