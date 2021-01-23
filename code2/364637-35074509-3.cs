     public class AutoMapperConfig
     {
         public static void RegisterMappings()
         {
             Mapper.CreateMap<User, DTOsModel>()
                   .MaxDepth(1);
         }
     }
