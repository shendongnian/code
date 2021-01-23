Provided MyOtherClass1, MyOtherClass2 all derrive from MyOtherBaseClass, the following code may help you:
    public class YourTypeBuilderBuilder
    {
        private readonly static IDictionary&lt;Type, Func&lt;object, MyOtherBaseClass>> builderMap = new Dictionary&lt;Type, Func&lt;object, MyOtherBaseClass>>();
        static YourTypeBuilderBuilder()
        {
            /* Here is described the specific behavior 
            of the building of the requested type */
            builderMap.Add(typeof(MyClass1), obj => new MyOtherClass1((MyClass1)obj));
            builderMap.Add(typeof(MyClass2), obj => new MyOtherClass2((MyClass2)obj));
            builderMap.Add(typeof(MyClass3), obj => new MyOtherClass3((MyClass3)obj));
        }
        public static MyOtherBaseClass Build&lt;T>(T input)
        {
            Func&lt;object, MyOtherBaseClass> typeBuilder;
            bool hasTypeBeenFound = builderMap.TryGetValue(typeof(T), out typeBuilder);
            if (!hasTypeBeenFound)
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid parameter.", typeof(T)));
            }
            // Let's build the requested type
            MyOtherBaseClass obj = typeBuilder(input);
            return obj;
        }
    }</code></pre>
Then your calling code would turn into
myOtherObject = YourTypeBuilder.Build(myObject);
