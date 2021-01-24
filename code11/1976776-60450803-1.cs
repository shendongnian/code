    public class Place
      {
        [Key, Column("id")]
        public int Id { get; set; }
    
        [Column("name")]
        public string Name { get; set; }
    
        public static explicit operator Place(PlaceDTO dto)
        {
          return new Place()
          {
            Id = dto.Id,
            Name = dto.Name
          };
        }
      }
    
      public class PlaceDTO
      {
        [Key, Column("id")]
        public int Id { get; set; }
    
        [Column("name")]
        public Localized<string> Name { get; set; }
    
        public static explicit operator PlaceDTO(Place pls)
        {
          return new PlaceDTO()
          {
            Id = pls.Id,
            Name = pls.Name
          };
        }
      }
    
    
      var placeDTO = (placeDto)place;
