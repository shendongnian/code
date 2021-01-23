	internal abstract class AuditEventTask<TEntity>
	{
		internal readonly AuditEvent AuditEvent;
		internal AuditEventTask()
		{
			AuditEvent = InitializeAuditEvent();
		}
		internal void Add(UnitOfWork unitOfWork)
		{
			if (unitOfWork == null)
			{
				throw new ArgumentNullException(Resources.UnitOfWorkRequired_Message);
			}
			new AuditEventRepository(unitOfWork).Add(AuditEvent);
		}
		private AuditEvent InitializeAuditEvent()
		{
			return new AuditEvent {Event = SetEvent(), Timestamp = DateTime.UtcNow};
		}
		internal abstract void Log(UnitOfWork unitOfWork, TEntity entity, string appUserName, string adminUserName);
		protected abstract string SetEvent();
	}
