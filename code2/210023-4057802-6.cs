    using(YourDataContextHere ctx = new YourDataContextHere())
    {
       SomeClassOfYours item = new SomeClassOfYours();
       item.ByteContent = (your byte content here);
       ctx.SomeClassOfYourses.InsertOnSubmit(item);
       ctx.SubmitChanges();
    }
