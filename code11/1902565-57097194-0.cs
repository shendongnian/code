      public class BookDTO
      {
         public int Id { get; set; }
         public string Title { get; set; }
         
         public class MapProfile:AutoMapper.Profile{
              public MapProfile(){
                  CreateMap<Book,BookDTO>().ReverseMap();
              }
         }
      }
      public class AuthorDTO
      {
         public int Id { get; set; }
         public string Name { get; set; }
         public List<BookDTO> Books { get; set; }
         public class MapProfile:AutoMapper.Profile{
              public MapProfile(){
                  CreateMap<Author,AuthorDTO>()
                  .ForMember(dest.Id, opt => opt.MapFrom(src.Id))
                  .ForMember(dest.Name, opt => opt.MapFrom(src.Name))
                  .ForMember(dest.Books, opt => opt.MapFrom(src.Books));
              }
         }
      }
