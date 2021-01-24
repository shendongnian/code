private string TypeConverter(Person person)
{
	if (person.IsHomeOwner)
	{
	  return Status.Homeowner;
	}
	else if (person.IsTenant)
	{
	  return Status.Tenant;
	}
	else
	{
	  return Status.LivingWithParents;
	}
	return person.Status;
}
Mapping configuration
CreateMap<Person, PersonDTO>()
                .ForMember(dest => dest.LivingStatus, opt => opt.MapFrom(src => TypeConverter(src)));
