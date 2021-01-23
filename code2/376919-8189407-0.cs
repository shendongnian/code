        public interface IEnums
        {
            public enum Mode { New, Selected };
        }
    
        public class MyClass1
        {
            public IEnums.Mode ModeProperty { get; set; }
        }
    
        public class MyClass2
        {
            public MyClass2()
            {
                var myClass1 = new MyClass1();
    
                //this will work
                myClass1.ModeProperty = IEnums.Mode.New;
            }
        }
