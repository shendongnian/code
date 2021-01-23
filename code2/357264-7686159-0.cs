    [Test]
    public void TestSelectPatientLink()
    {
        try
        {
            Link lnkSelectPatientb = ie.Link(Find.ByTitle("Search patient"));
            lnkSelectPatientb.Blur();
            lnkSelectPatientb.ClickNoWait();
        }
        catch (Exception ex)
        {
            // Capture the error screen so you can see what went wrong
            ie.CaptureWebPageToFile("Error.jpg");
            // Fail the test, use the unit testing framework's reporting to get your pass/fail
            Assert.Fail(ex.ToString());
        }
    }
