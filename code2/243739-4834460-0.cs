    class Program
        {
            static void Main(string[] args)
            {
                MyClass myClass = new MyClass();
                myClass.arrOfObj = GetData();
                foreach (var item in myClass.arrOfObj)
                {
                    Console.WriteLine(item.ToString());
                }
            Console.ReadLine();
        }
        private static int[] GetData()
        {
            return new int[]{1,2,3,4,5};
        }
    }
    public class MyClass
    {
        public int[] arrOfObj; //Array of objects
    }
