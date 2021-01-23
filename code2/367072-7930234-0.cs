    // Our FieldReference class that internally uses reflection to get or set a field value.
    public class FieldReference<T>
    {
        private object ownerObject;
        private FieldInfo fieldInfo;
        public FieldReference(object ownerObject, string fieldName)
        {
            this.ownerObject = ownerObject;
            this.fieldInfo = ownerObject.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        }
        public FieldReference(object ownerObject, FieldInfo fieldInfo)
        {
            this.ownerObject = ownerObject;
            this.fieldInfo = fieldInfo;
        }
        public T Value
        {
            get { return (T)this.fieldInfo.GetValue(this.ownerObject); }
            set { this.fieldInfo.SetValue(this.ownerObject, value); }
        }
    }
    // Our dummy class
    public class MyClass
    {
        // Our field we want to expose.
        private int myField;
        public MyClass(int value)
        {
            this.myField = value;
        }
        // Just a function we use to print the content of myField.
        public override string ToString()
        {
            return this.myField.ToString();
        }
    }
    class Program
    {
        public static void Main()
        {
            // We create our class.
            MyClass mc = new MyClass(5);
            
            // We print field value, should be 5 :)
            Console.WriteLine(mc.ToString());
            // We create our field reference
            FieldReference<int> fieldref = new FieldReference<int>(mc, "myField");
            // We set the value using field reference.
            // Note, we accessed a private field :)
            fieldref.Value = 100;
            // Now we print the value, should be 100!
            Console.WriteLine(mc.ToString());
            Console.ReadLine();
        }
    }
