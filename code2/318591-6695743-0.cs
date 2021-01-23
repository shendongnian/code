    InvoiceLine invoiceLineAlias = null;
    var list = session.QueryOver<Invoice>()
                      .Where(x => x.Id == 1)
                      .JoinQueryOver(x => x.Lines, () => invoiceLineAlias, JoinType.LeftOuterJoin)
                      .WhereRestrictionOn(() => invoiceLineAlias.LineNumber)
                      .IsIn(new List<int> { 1, 2, 3 })
                      .List();
