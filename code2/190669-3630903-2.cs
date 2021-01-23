    Mock<IRepository> repMock = new Mock<IRepository>();
    MyPage obj = new MyPage() //let's pretend this is ASP.NET
    obj.IRepository = repMock.Object;
    repMock.Setup(r => r.FindById(1)).Returns(MyTestObject.GetThingies().First());
    var thingie = MyPage.GetThingie(1);
