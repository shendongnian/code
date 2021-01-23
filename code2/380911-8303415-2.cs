    namespace Test
    {
        public class Calculator
        {
            public Calculator() { ... }
            private double _number;
            public double Number { get { ... } set { ... } }
            public void Clear() { ... }
            private void DoClear() { ... }
            public double Add(double number) { ... }
            public static double Pi { ... }
            public static double GetPi() { ... }
        }
    }
    
    Calculator calc = new Calculator();
    // invoke private instance method: private void DoClear()
    calcType.InvokeMember("DoClear",
        BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic,
        null, calc, null);
