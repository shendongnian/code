    [Test]
    public void TestUnprocessedInvoices()
    {
        IList<InvoiceDTO> expectedResults = new List<InvoiceDTO>();
        _invoiceRepository.Find(Arg.Any<Expression<Func<Invoice, bool>>>()).Returns(expectedResults);
    }
