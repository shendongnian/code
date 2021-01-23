    DelimitedClassBuilder cb = new DelimitedClassBuilder("BaseCustomer", delimiter);
    
    cb.AddField("CustId", typeof(int));
    cb.LastField.TrimMode = TrimMode.Both;
    cb.LastField.FieldNullValue = 0;
    cb.AddField("Balance", typeof(Decimal));
    cb.AddField("AddedDate", typeof(DateTime));
    engine = new FileHelperEngine(cb.CreateRecordClass());
    DataTable dt = engine.ReadFileAsDT("test.txt");
