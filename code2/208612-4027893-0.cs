    Bind<LoggedTextWriter>().ToSelf();
    Bind<ICustomWriter>().To<MyCustomWriter>();
    Bind<DataContext>().ToMethod(x => 
        new DataContext(@"Data Source=localhost\sqlexpress2008;Initial Catalog=MyDB;Integrated Security=True")
        {
            ObjectTrackingEnabled = true,
            Log = x.Kernel.Get<LoggedTextWriter>()
        });
