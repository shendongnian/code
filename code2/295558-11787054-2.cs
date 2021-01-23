		public static void Using(Db db, Action<Db> action)
		{
			if (db == null)
			{
				using (db = new Db())
				{
					action(db);
				}
			}
			else
			{
				action(db);
			}
		}
