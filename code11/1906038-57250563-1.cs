    internal class Program
    {
        public static List<SptDetailExtended> InitializeExtendedObjects()
        {
            var details = new List<SptDetail>
            {
                new SptDetail
                {
                    Age = "10",
                    Name = "Marion"
                },
                new SptDetail
                {
                    Age = "11",
                    Name = "Elisabeth"
                }
            };
            //this is wrong db.spt_detail.ToList();
    
            Mapper.Initialize(n => n.CreateMap<SptDetail, SptDetailExtended>() 
              /*you need to use ForMember*/ .ForMember(obj => obj.ExProp1, obj => obj.MapFrom(src => src.Name))
                                            .ForMember(obj => obj.ExProp2, obj => obj.MapFrom(src => src.Age)));
    
            //instead of this Mapper.Initialize(n => n.CreateMap<List<spt_detail>, List<spt_detail_extended>>());
    
            //change your mapping like following too
            var cenr = Mapper.Map<List<SptDetailExtended>>(details);
            return cenr;
        }
        private static void Main(string[] args)
        {
            var result = InitializeExtendedObjects();
            foreach (var sptDetailExtended in result)
            {
                Console.WriteLine(sptDetailExtended.ExProp1);
                Console.WriteLine(sptDetailExtended.ExProp2);
            }
            Console.ReadLine();
        }
    }
