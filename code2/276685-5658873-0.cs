    //Class under test uses:
    _invoiceRepository.Find(Queries.UnprocessedConfirmedOrders)
    [Test]
    public void TestUnprocessedInvoices()
    {
        IList<InvoiceDTO> expectedResults = new List<InvoiceDTO>();
        _invoiceRepository.Find(Queries.UnprocessedConfirmedOrders).Returns(expectedResults);
        Assert.That(_sut.GetUnprocessedInvoices(), Is.SameAs(expectedResults));
    }
