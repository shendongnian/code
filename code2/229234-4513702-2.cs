     Mapper.CreateMap<BaseClass, ViewModel>()
           .Include<Subclass1, ViewModel1>();
     Mapper.CreateMap<Subclass1, ViewModel1>();
     var items = new List<BaseClass> {new Subclass1 {BaseName = "Base", SubName1 = "Sub1"}};
     var viewModels = Mapper.Map(items, new List<ViewModel>());
