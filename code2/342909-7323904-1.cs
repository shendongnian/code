    [Theory, AutoMoqData]
    public void SampleTableHtmlHelper_WhenKeyExistWithinHttpContext_ReturnsExpectedHtml(
        [Frozen]ViewContext vc,
        HtmlHelper htmlHelper,
        SampleModel sampleModel)
    {
        //Arrange
        vc.HttpContext.Items.Add(Keys.SomeKey, "foo");
        //Act
        var result = SampleHelpers.SampleTable(htmlHelper, sampleModel, null).ToString();
        //Assert
        Assert.Equal("<table id=\"foo\"></table>", result);
    }
