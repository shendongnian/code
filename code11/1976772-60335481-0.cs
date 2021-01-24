    public class Place
    {
        [Key, Column("id")]
        public int Id { get; set; }
    
        [Column("name")]
        public string Name { get; set; }
    }
    
    public class PlaceDTO
    {
        [Key, Column("id")]
        public int Id { get; set; }
    
        [Column("name")]
        public Localized<string> Name { get; set; }
    }
    
    public class Localized<T>
    {
        public T en { get; set; } // english localization
        public T ar { get; set; } // arabic localization
        public T fr { get; set; } // french localization
    }
