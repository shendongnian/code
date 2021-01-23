    public class ParamsTest
    {
        public void CallMyMethod()
        {
            Action<string, int[]> myDelegate = new Action<string, int[]>(MyMethod);
            myDelegate("hello", new int[] { 1, 2, 3, 4 });
        }
        private void MyMethod(string arg1, params int[] theRest)
        {
            Console.WriteLine(arg1);
            foreach (int i in theRest)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("end");
        }
    }
