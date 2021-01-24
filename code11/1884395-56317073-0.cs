    public interface IGeneric<T, U>
    {
        T InterfaceOne { get; }
        U InterfaceTwo { get; }
    }
    public class GenericClass : IGeneric<IInterfaceOne, IInterfaceTwo>
    {
        private readonly IInterfaceOne interfaceOne;
        private readonly IInterfaceTwo interfaceTwo;
        public GenericClass(IInterfaceOne interfaceOne, IInterfaceTwo interfaceTwo)
        {
            this.interfaceOne = interfaceOne;
            this.interfaceTwo = interfaceTwo;
        }
        public IInterfaceOne InterfaceOne { get { return this.interfaceOne; } }
        public IInterfaceTwo InterfaceTwo { get { return this.interfaceTwo; } }
    }
    public class ClassOne : IInterfaceOne
    {
        public void DoOne()
        {
            throw new NotImplementedException();
        }
        public void DoTwo()
        {
            throw new NotImplementedException();
        }
    }
    public class ClassTwo : IInterfaceTwo
    {
        public void DoFour()
        {
            throw new NotImplementedException();
        }
        public void DoThree()
        {
            throw new NotImplementedException();
        }
    }
