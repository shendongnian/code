    namespace ExampleNamespace
    {
      public interface IJustAInstance { }
      [ServiceContract]
      [ServiceKnownType("GetKnownTypes", typeof(ExampleNamespace.TypesHelper))]
      public interface ICreateInstance
      {
        IJustAInstance CreateInstance();
      }
      public static class TypesHelper
      {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
          DataContractSerializerSection section = (DataContractSerializerSection)
            ConfigurationManager.GetSection(
            "system.runtime.serialization/dataContractSerializer");
          if (dataContractSerializerSection != null)
          {
            foreach (DeclaredTypeElement item in dataContractSerializerSection.DeclaredTypes)
            {
              foreach (TypeElement innterItem in item.KnownTypes)
              {
                Type type = Type.GetType(innterItem.Type);
                if (typeof(IJustAInstance).IsAssignableFrom(type ))
                  yield return type;
              }
            }
          }
        }
      }
    }
