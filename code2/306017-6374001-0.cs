    var db = new StoreDataContext();
    Int32 lineNo = DbMethods.GetNextLine(p.order_fk);
    var inserts = payments.Select(p => new payment 
    {
      order_fk = p.order_fk,
      amount = p.amount
    });
    foreach(var item on inserts)
    {
      item.line_no = LineNo;
      LineNo++;
    }
    db.payments.InsertAllOnSubmit(inserts);
    db.SubmitChanges(ConflictMode.FailOnFirstConflict);
