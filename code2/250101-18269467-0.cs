    using(var db = new Tpr.Models.MyContext())
	{
		var model = _uow._context.Database.SqlQuery<MyTable>(string.Format("select * from MyTable where ID = '{0}'", "12345678"));
		Assert.IsNotNull(model);
	}
