	public class AuditEvent : EntityBase
	{
		public string Event { get; set; }
		public virtual AppUser AppUser { get; set; }
		public virtual AppUser AdminUser { get; set; }
		public string Message{get;set;}
		private DateTime _timestamp;
		public DateTime Timestamp
		{
			get { return _timestamp == DateTime.MinValue ? DateTime.UtcNow : _timestamp; }
			set { _timestamp = value; }
		}
		public virtual Company Company { get; set; }
    // etc.
        }
