    public class AppointmentMap : ClassMap<Appointment>
        {
            public AppointmentMap()
            {
                Id(c => c.Id);
                HasMany(a => a.AppointmentParticipants).Inverse().KeyColumn("FkAppointmentsId").Cascade.All();
                References(a => a.Location).Column("FkAddressId");
                Map(a => a.DateAndTime).Column("AppointmentDate").CustomType<UtcDateTimeType>();
                Map(a => a.Description).Column("AppointmentDescription");
                Map(a => a.Status).Column("AppointmentStatus").CustomType<AppointmentStatus>();
                HasMany(a => a.AppointmentEstates).Inverse().KeyColumn("FkAppointmentsId").Cascade.All();
                Table("Appointments");
            }
    	}
