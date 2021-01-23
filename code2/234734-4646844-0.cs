    public class Concrete : AbstractClass
    {
        public new void DoSomething()
        {
            Console.WriteLine(Value);
        }
    }
    
    public abstract class AbstractClass
    {
        protected AbstractClass()
        {
            try
            {
                var value = Value;
            }
            catch (NotImplementedException)
            {
                throw new Exception("Value's getter must be overriden in base class");
            }
        }
        public void DoSomething()
        {
            Console.WriteLine(Value);
        }
    
        /// <summary>
        /// Must be override in subclass
        /// </summary>
        public string Value { get { throw new NotImplementedException(); } }
    }
