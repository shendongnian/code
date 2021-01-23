	// Where `BaseDB` is your Entities object... (it could be `this` in a different design)
	public void Save(bool? validateEntities = null)
	{
		try
		{
			//Capture and set the validation state if we decide to
			bool validateOnSaveEnabledStartState = BaseDB.Configuration.ValidateOnSaveEnabled;
			if (validateEntities.HasValue)
				BaseDB.Configuration.ValidateOnSaveEnabled = validateEntities.Value;
			BaseDB.SaveChanges();
			//Revert the validation state when done
			if (validateEntities.HasValue)
				BaseDB.Configuration.ValidateOnSaveEnabled = validateOnSaveEnabledStartState;
		}
		catch (DbEntityValidationException e)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var eve in e.EntityValidationErrors)
			{
				sb.AppendLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", 
												eve.Entry.Entity.GetType().Name,
												eve.Entry.State));
				foreach (var ve in eve.ValidationErrors)
				{
					sb.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"",
												ve.PropertyName,
												ve.ErrorMessage));
				}
			}
			throw new DbEntityValidationException(sb.ToString(), e);
		}
	}
