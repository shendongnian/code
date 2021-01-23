    #region [ EnumNamedConstantAttribute ]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumNamedConstantAttribute : Attribute
    {
        public string Description { get; set; }
        public string Value { get; set; }
    }
    #endregion
    #region EnumUtilities
    public static class EnumUtilities
    {
        #region [ + Extension Methods ]
        #region [ GetDescription ]
        public static string GetDescription(this Enum constant)
        {
            return EnumUtilities.GetEnumNamedConstantAttribute(constant).Description;
        }
        #endregion
        #region [ GetStringValue ]
        public static string GetStringValue(this Enum constant)
        {
            return GetEnumNamedConstantValue(constant);
        }
        #endregion
        #endregion
        #region [ + Static Methods ]
        #region [ GetEnumerable ]
        public static IEnumerable<EnumNamedConstantAttribute> GetEnumerable<T>()
        {
            T instancia = Activator.CreateInstance<T>();
            FieldInfo[] objInfos = instancia.GetType().GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (FieldInfo objFileInfo in objInfos)
            {
                Enum constant = (Enum)objFileInfo.GetValue(objFileInfo);
                if (objFileInfo.GetCustomAttributes(typeof(EnumNamedConstantAttribute), false).Length != 0)
                {
                    yield return new EnumNamedConstantAttribute()
                    {
                        Description = EnumUtilities.GetEnumNamedConstantAttribute(constant).Description,
                        Value = GetEnumNamedConstantValue(constant)
                    };
                }
            }
        }
        #endregion
        #endregion
        #region [ + Privates ]
        #region [ GetEnumNamedConstantAttribute ]
        private static EnumNamedConstantAttribute GetEnumNamedConstantAttribute(Enum constant)
        {
            FieldInfo[] objInfos = constant.GetType().GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (FieldInfo objFileInfo in objInfos)
            {
                Enum constantItem = (Enum)objFileInfo.GetValue(objFileInfo);
                if (constantItem.GetHashCode().Equals(constant.GetHashCode()))
                {
                    object[] attributes = objFileInfo.GetCustomAttributes(typeof(EnumNamedConstantAttribute), false);
                    if (attributes.Length > 0)
                        return (EnumNamedConstantAttribute)attributes[0];
                }
            }
            return null;
        }
        #endregion
        #region [ GetEnumNamedConstantValue ]
        private static string GetEnumNamedConstantValue(Enum constant)
        {
            string sValue = (constant.GetHashCode()).ToString();
            EnumNamedConstantAttribute objRet = EnumUtilities.GetEnumNamedConstantAttribute(constant);
            if (objRet != null)
            {
                String sAux = objRet.Value;
                if (!String.IsNullOrEmpty(sAux))
                    sValue = objRet.Value;
            }
            return sValue;
        }
        #endregion
        #endregion
    }
    #endregion
