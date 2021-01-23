	internal class EmailAuditEventTask : AuditEventTask<Email>
	{
		internal override void Log(UnitOfWork unitOfWork, Email email, string appUserName, string adminUserName)
		{
			AppUser appUser = new AppUserRepository(unitOfWork).Find(au => au.Email.Equals(appUserName, StringComparison.OrdinalIgnoreCase));
			AuditEvent.AppUser = appUser;
			AuditEvent.Company = appUser.Company;
			AuditEvent.Message = email.EmailType;
			Add(unitOfWork);
		}
		protected override string SetEvent()
		{
			return AuditEvent.SendEmail;
		}
	}
 
