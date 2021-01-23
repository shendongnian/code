    var pageModel = new Mock<IPageModel>();
    IPageModel pageModelNull = null;
    var pageModels = new Queue<IPageModel>();
    pageModels.Enqueue(pageModelNull);
    pageModels.Enqueue(pageModel.Object);
