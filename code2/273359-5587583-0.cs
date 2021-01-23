    [TestMethod, ExpectedException(typeof(ParserValidationException))]
    public void IllegalDataShouldThrowValidationErrors()
    {
        var parser = new MyParser();
        parser.Parse( dataThatContainsErrors );
    }
