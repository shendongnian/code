    public class MyProfile : Profile
    {
        public MyProfile ()
        {
            CreateMap<Item, Item>().ForMember(x => x.Name, opt => opt.Ignore()) ;
           
        }
    }
