    [Test]
    public void Properly_Generates_DerivedName()
    {
        var widgetCreator = new Mock<IWidgetCreator>();
        
        var presenter = new WidgetCreatorPresenter(widgetCreator.Object);
        presenter.Save("Name");
        widgetCreator.Verify(a => a.Create(MatchesWidget("Derived.Name"));
    }
    private Widget MatchesWidget(string derivedName)
    {
        return It.Is<Widget>(m => m.DerivedName == derivedName);
    }
