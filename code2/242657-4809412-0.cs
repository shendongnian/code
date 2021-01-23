    private static void DoMyStuff(MyThing thing)
    {
        using (MyDataContext db = new MyDataContext())
        {
           db.MyThings.Attach(thing);
           thing.Status = 1;
           db.SubmitChanges();
        }
    }
