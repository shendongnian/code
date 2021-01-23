    public interface IXyz
    {
      int Id { get; }
    }
     
    //Test Side Code    
    var _mock = new Mock<IXyz>();
    _mock.SetupProperty(x => x.Id, 1054);
