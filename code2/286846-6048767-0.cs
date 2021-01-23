    public class Foo
    {
      private IService _service;
      public EventHandler CalculationComplete;
      public Foo(IService service) 
      {
      	_service = service;
    	_service.DoCompleted += (o,e) => 
    	{
                Calculated = e.Result;
    	    if(CalculationComplete != null) { CalculationComplete(this, new EventArgs()); }
    	};
      }
      public int Calculated;
      public void CalculateAsync(int param)
      {
    	_service.DoAsync(param);
      }
    }
    
    
    public interface IService
    {
    	void DoAsync(int param);
    	event EventHandler<DoResultEventArgs> DoCompleted;
    }
    
    public class DoResultEventArgs : EventArgs
    {
        public int Result { get; set; }
    }
    
    [TestMethod]
    public void CalculateAsync_CallsService_CalculatedIsPopulated()
    {
    	//Arrange
    	Mock<IService> sMock = new Mock<IService>();
    	sMock.Setup(s => s.DoAsync(It.IsAny<int>()))
                 .Raises(s => s.DoCompleted += null, new DoResultEventArgs() { Result = 324 });
    	
    	Foo foo = new Foo(sMock.Object);
    	
    	AutoResetEvent waitHandle = new AutoResetEvent(false);
    	foo.CalculationComplete += (o,e) => waitHandle.Set();
    	
    	//Act
    	foo.CalculateAsync(12);
    	waitHandle.WaitOne();
    	
    	//Assert
    	Assert.IsEqual(foo.Calculated, 324);
    }
