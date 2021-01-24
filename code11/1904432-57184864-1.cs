	internal sealed class AppointmentMapper : ClassMapper<Appointment>
	{
		public AppointmentMapper()
		{
			Table("Appointment");
			Map(x => x.AppointmentUUID).Key(KeyType.Guid);//<--Just map this
			AutoMap();//<-- This will take care about all other columns you do not map explicitly; ofcouse based on conversions
		}
	}
