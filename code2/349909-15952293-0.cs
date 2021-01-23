    public class TypeReplacementSurrogate : IDataContractSurrogate
    {
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            return null;
        }
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            return null;
        }
        public Type GetDataContractType(Type type)
        {
            if(type == typeof(Type))
            {
                return typeof (TypeWrapper);
            }
            return type;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            var objAsTypeWrapper = obj as TypeWrapper;
            if (objAsTypeWrapper != null)
            {
                return Assembly.GetExecutingAssembly().GetType(objAsTypeWrapper.TypeName);
            }
            return obj;
        }
        public void GetKnownCustomDataTypes(System.Collections.ObjectModel.Collection<Type> customDataTypes)
        {
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            var objAsType = obj as Type;
            if (objAsType != null)
            {
                return new TypeWrapper() {TypeName = objAsType.FullName};
            }
            return obj;
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            return null;
        }
        public System.CodeDom.CodeTypeDeclaration ProcessImportedType(
            System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit)
        {
            return null;
        }
    }
