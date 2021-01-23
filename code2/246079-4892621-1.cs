        DataClassesDataContext ctx = new DataClassesDataContext();
        Application a1 = new Application();
        XName n = "dfdsf";
        a1.ApplicationData = new XElement(n);
        ctx.Applications.InsertOnSubmit(a1);
        ctx.SubmitChanges();
