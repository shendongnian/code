        public struct MyResultValues //could be public class MyResultValues
        {
            public int result1;
            public string result2;
        }
        MyResultValues result = MyFunction();
        Console.WriteLine(result.result1);
        Console.WriteLine(result.result2);
        public MyResultValues MyFunction()
        {
            MyResultValues toReturn = new MyResultValues();
            toReturn.result1 = 10;
            toReturn.result2 = "Hello World !";
            return toReturn;
        }
