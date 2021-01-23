		public static async Task Using(Db db, Func<Db, Task> action)
		{
			if (db == null)
			{
				using (db = new Db())
				{
					await action(db);
				}
			}
			else
			{
				await action(db);
			}
		}
