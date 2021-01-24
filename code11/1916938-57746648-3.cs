    modelBuilder.Entity<EventCode>()
    	.ToTable("Event_Code");
    modelBuilder.Entity<EventCode>()
    	.HasKey(e => new { e.EventId, e.SessionCode, e.LicenseKey });
    modelBuilder.Entity<EventCode>().Property(e => e.EventId)
    	.HasColumnName("event_id");
    modelBuilder.Entity<EventCode>().Property(e => e.SessionCode)
    	.HasColumnName("session_code");
    modelBuilder.Entity<EventCode>().Property(e => e.LicenseKey)
    	.HasColumnName("license_key");
    modelBuilder.Entity<EventCode>()
    	.HasRequired(e => e.Event)
    	.WithMany(e => e.EventCodes)
    	.HasForeignKey(e => new { e.EventId, e.LicenseKey });
    modelBuilder.Entity<EventCode>()
    	.HasRequired(e => e.Code)
    	.WithMany()
    	.HasForeignKey(e => new { e.SessionCode, e.LicenseKey });
