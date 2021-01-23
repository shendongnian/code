    // Class used to read and write your data
    public class DataBuilder : Data {
        public void SetValue(int value) {
            base.m_SomeValue = value; // Has access to protected member
        }
    }
    // Class used to store your data (READONLY)
    public class Data {
        protected int m_SomeValue; // Is accessible to deriving class
        public int SomeValue {     // READONLY property to other classes
                                   // EXCEPT deriving classes
            get {
                return m_SomeValue;
            }
        }
    }
    public class AnyOtherClass {
        public void Foo() {
            DataBuilder reader = new DataBuilder();
            Console.WriteLine(reader.SomeValue); // *CAN* read the value
            reader.SomeValue = 100; // CANNOT *write* the value
        }
    }
