    using(var Database = new DataDataContext())
     {
		tests test = new tests();
		test.Name = Name;
		test.Quantity = (short)Quantitty;
		Database.tests.InsertOnSubmit(test);
		try
		{
			Database.SubmitChanges();
		}
		catch (ChangeConflictException e)
		{
			//report error, log error whatever...
		}
    }
