    [Test]
    public void TestUnprocessedInvoicesByCatchingExpression()
    {
        Expression<Func<InvoiceDTO, bool>> queryUsed = null;
        IList<InvoiceDTO> expectedResults = new List<InvoiceDTO>();
        _invoiceRepository
            .Find(i => true)
            .ReturnsForAnyArgs(x =>
            {
                queryUsed = (Expression<Func<InvoiceDTO, bool>>)x[0];
                return expectedResults;
            });
        Assert.That(_sut.GetUnprocessedInvoices(), Is.SameAs(expectedResults));
        AssertQueryPassesFor(queryUsed, new InvoiceDTO { IsProcessed = false, IsConfirmed = true });
        AssertQueryFailsFor(queryUsed, new InvoiceDTO { IsProcessed = true, IsConfirmed = true });
    }
