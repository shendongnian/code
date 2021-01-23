    namespace AutoProperties
        {
            interface IMyInterface
            {
                bool MyBoolOnlyGet { get; set; }
            }
    
            class MyClass : IMyInterface
            {
                static void Main() { }
    
                bool IMyInterface.MyBoolOnlyGet { get; set; } 
            }
        }
