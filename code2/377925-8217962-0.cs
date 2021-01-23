    namespace TestLibrary
    {
        [TestFixture]
        public class Tests
        {
            [Test]
            public void FileCheck()
            {
                dynamic otherClass = 
                    AppDomain.CurrentDomain.CreateInstanceFromAndUnwrap("OtherLibrary.dll",                
                        "Prefix.OtherLibrary.SomeClass");
                otherClass.SayHello();   // look, ma! no casting or interfaces!
            }
        }
    }
    
    namespace Prefix.OtherLibrary
    {
        public class SomeClass
        {
            public void SayHello()
            {
                Console.WriteLine("Hello, world.");
            }
        }
    }
