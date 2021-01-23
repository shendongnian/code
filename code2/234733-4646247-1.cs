    public abstract class AbstractClass {
        public abstract string Value { get; }
    }
    public class ConcreteClass : AbstractClass {
        private string m_Value;
        public override string Value {
            get { return m_Value; }
        }
        public void SetValue(string value) {
            m_Value = value;
        }
    }
