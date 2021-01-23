        DataClassesDataContext ctx = new DataClassesDataContext();
        Application a1 = new Application();
        XName n = "dfdsf";
        a1.ApplicationData = new XElement(n);
        ctx.Table1s.InsertOnSubmit(a1);
        ctx.SubmitChanges();
