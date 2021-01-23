	public static class DbContextExtension
	{
		public static int Truncates(this DbContext db, params string[] tables)
		{
			List<string> target = new List<string>();
			int result = 0;
			if (tables == null || tables.Length == 0)
			{
				target = db.GetTableList();
			}
			else
			{
				target.AddRange(tables);
			}
			using (TransactionScope scope = new TransactionScope())
			{
				foreach (var table in target)
				{
					result += db.Database.ExecuteSqlCommand(string.Format("DELETE FROM  [{0}]", table));
					db.Database.ExecuteSqlCommand(string.Format("DBCC CHECKIDENT ([{0}], RESEED, 0)", table));
				}
				
				scope.Complete();
			}
			return result;
		}
		public static List<string> GetTableList(this DbContext db)
		{
			var type = db.GetType();
			return db.GetType().GetProperties()
				.Where(x => x.PropertyType.Name == "DbSet`1")
				.Select(x => x.Name).ToList();
		}
	}
