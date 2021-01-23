    public class User
	{
		public virtual string Name
		{
			get;
			set;
		}
		public virtual string Gender
		{
			get;
			set;
		}
	}
	public class UserGender : User
	{
		public override string Name
		{
			get
			{
				return string.Empty;
			}
			set
			{
			}
		}
	}
    Mapper.CreateMap<User, UserGender>()
            .ForMember(d => d.FirstName, o => o.Ignore())
            .ForMember(d => d.Gender, o => o.MapFrom(s => s.Gender));
