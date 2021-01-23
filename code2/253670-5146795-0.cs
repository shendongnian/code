    private Mock<IItemService> _service;
    private Mock<IItemNewView> _view;
    private PresenterBase<IItemNewView> CreateSUT()
    {
        _service = new Mock<IItemService>();
        _view = new Mock<IItemNewView>();
        return new ItemNewPresenter (service.Object, view.Object);
    }
