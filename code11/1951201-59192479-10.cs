	public IEnumerable<Model> GetAllById(int id)
	{
		// you will need to uncomment the following line to work with your key
		//_dbContext.Database.ExecuteSqlCommand("OPEN SYMMETRIC KEY {1} DECRYPTION BY PASSWORD = '{2}';", SymmetricKeyName, SymmetricKeyPassword);
		var filteredSet = Set.Include(x => x.Table2)
			.Where(x => x.Id == id)
			.Where(x => x.Table2.IsSomething)
			.Select(m => new Model
		{
			Id = m.Id,
			//Decrypted = EF.Functions.DecryptByKey(m.Encrypted), // since the key's opened for session scope - just relying on it should do the trick
			Decrypted = EF.Functions.Decrypt("test", m.Encrypted),
			Table2 = m.Table2,
			Encrypted = m.Encrypted
		}).ToList();
		// you will need to uncomment the following line to work with your key
		//_dbContext.Database.ExecuteSqlCommand("CLOSE SYMMETRIC KEY {1};", SymmetricKeyName);
		return filteredSet;
	}
