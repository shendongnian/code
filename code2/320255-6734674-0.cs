    class Program
        {
            static void Main(string[] args)
            {
                // the app is starting here
                InitializeAutomapper();
                // we're configured, let's go!
                DoStuff();
            }
    
            static void InitializeAutomapper()
            {
                AutoMapper.Mapper.CreateMap<TypeA, TypeB>();
                AutoMapper.Mapper.CreateMap<TypeC, TypeD>();
                AutoMapper.Mapper.CreateMap<TypeE, TypeF>();
            }
        }
