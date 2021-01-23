    // the class that contains the CreateIndex<T> method.  Note that you will have to change the BindingFlags if this method is static
    public class IndexCreator
    {
        // your method
        public BTree<T, object> CreateIndex<T>(string path, string fieldName)
                where T : IComparable
        {
            // method body
        }
        // generic method
        public object CreateIndex(Type indexType, string path, string fieldName)
        {
            var genericMethod = GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Single(methodInfo => methodInfo.Name == "CreateIndex" && methodInfo.IsGenericMethodDefinition)
                .MakeGenericMethod(indexType);
            return genericMethod.Invoke(this, new object[]{path, fieldName});
        }
    }
