    abstract class PureVirtual
    {
        public abstract void PureVirtualMethod();
    }
    class Derivered : PureVirtual
    {
        public override void PureVirtualMethod()
        {
            Console.WriteLine("I'm pure virtual function");
        }
    }
