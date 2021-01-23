    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo( );
            foo.Set( );
    
            foreach (var data in foo.data2Check)
            {
                Console.WriteLine("{0} = {1}", data.type, data.objDest);
            }
    
            Console.ReadKey( );
        }
    }
    
    public class Foo
    {
        //These are two variables to fill
        string strDest = "";
        int nDest = 0;
        internal List<MyStruct> data2Check;
    
        public Foo( )
        {
            data2Check = new List<MyStruct>{
                    new MyStruct(MyDataType.MyTypeString, strDest),
                    new MyStruct(MyDataType.MyTypeInt, nDest),
                };
        }
    
        public void Set( )
        {
            //And set them
            for (int i = 0 ; i < data2Check.Count ; i++)
            {
                if (data2Check[i].type == MyDataType.MyTypeString)
                {
                    data2Check[i] = new MyStruct(data2Check[i].type, "New value");
                }
                else if (data2Check[i].type == MyDataType.MyTypeInt)
                {
                    data2Check[i] = new MyStruct(data2Check[i].type, 2);
                }
            }
        }
    }
    
    public enum MyDataType
    {
        MyTypeString,
        MyTypeInt
    }
    
    public struct MyStruct
    {
        public MyDataType type;
        public Object objDest;
    
        public MyStruct(MyDataType tType, Object oDest)
        {
            type = tType;
            objDest = oDest;
        }
    }
