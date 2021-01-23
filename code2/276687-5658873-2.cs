    //Class under test now uses:
    _invoiceRepository.Find(new UnprocessedConfirmedOrdersQuery());
    [Test]
    public void TestUnprocessedInvoicesUsingSpecification()
    {
        IList<InvoiceDTO> expectedResults = new List<InvoiceDTO>();
        _invoiceRepository.Find(Arg.Any<UnprocessedConfirmedOrdersQuery>()).Returns(expectedResults);
        Assert.That(_sut.GetUnprocessedInvoices(), Is.SameAs(expectedResults));
    }
