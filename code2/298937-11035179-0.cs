    using Microsoft.SharePoint;
    [Test]
    public void RemoveHtml()
    {
        string textWithHtml = "<div class='ExternalCla48D45'>value</div>";
        textWithHtml = SPHttpUtility.ConvertSimpleHtmlToText(multilinetext, -1);
        Assert.That(textWithHtml, Is.EqualTo("value"));
    }
