        public class MyClass1
        {
            private enum Mode { New, Selected };
            public Mode ModeProperty { get; set; }
        }
    
        public class MyClass2
        {
            public MyClass2()
            {
                var myClass1 = new MyClass1();
    
                //this will not work due to protection level
                myClass1.ModeProperty = MyClass1.Mode.
            }
        }
