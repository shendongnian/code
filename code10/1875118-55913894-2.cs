    // configure mapping, hope you get the idea
    var map = Mapper.CreateMap<IDataReader, CustomerModel>()
      .ForMember(dest => dest.one,
          opt => opt.MapFrom(src => src.GetValue(src.GetOrdinal("one")).ToString())))
    // use
    using (DataTableReader dr = ds.Tables[0].CreateDataReader())
    {
        if (dr.HasRows)
        {
           var pr = AutoMapper.Mapper.Map<IDataReader, IList<OneViewModel>>(dr);
        }
    }
