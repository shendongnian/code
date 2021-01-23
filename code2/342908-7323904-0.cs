    [Fact]
    public void SampleTableHtmlHelper_WhenKeyExistWithinHttpContext_ReturnsExpectedHtml()
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        //Arrange
        var vc = fixture.Freeze<ViewContext>();
        vc.HttpContext.Items.Add(Keys.SomeKey, "foo");
        var htmlHelper = fixture.CreateAnonymous<HtmlHelper>();
        var sampleModel = fixture.CreateAnonymous<SampleModel>();
        //Act
        var result = SampleHelpers.SampleTable(htmlHelper, sampleModel, null).ToString();
        //Assert
        Assert.Equal("<table id=\"foo\"></table>", result);
    }
