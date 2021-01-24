C#
    public class UserAppointmentsMap : ClassMap<UserAppointment>
    {
        public UserAppointmentsMap()
        {
            CompositeId()
                .KeyReference(a => a.Appointment, "FkAppointmentsId")
                .KeyReference(u => u.User, "FkUserId");
            Table("UserAppointments");
        }
    }
 2. The Composite Id with foreign key should be done with KeyReference instead of KeyProperty
 3. I was having issue with wrongly generated query(the foreign key was wrong i.e. instead of FkAppointmentsId it was looking for Appointments_Id) so I had to specify the column name explicitly
C#
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
