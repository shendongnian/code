    using (var context = new DBContext())
    {
        IUnitOfWork uow = new UnitOfWork(context);
        ReminderRepository repository = new ReminderRepository(context);
        Reminder remainder = repository.GetReminderByName("...");
        remainder.SomeProperty = "updated value..";
        uow.Save();
    }
