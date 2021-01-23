    using System;
    using Rhino.Mocks;
    
    public abstract class Abstract
    {
        public virtual int Foo()
        {
            return Bar() * 2;
        }
        
        public abstract int Bar();        
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            // Arrange
            Abstract mock = MockRepository.GeneratePartialMock<Abstract>();
            mock.Stub(action => action.Bar()).Return(5);
            
            // Act
            int result = mock.Foo();
            
            // Assert
            mock.AssertWasCalled(x => x.Bar());
            // And assert that result is 10...
        }
    }
