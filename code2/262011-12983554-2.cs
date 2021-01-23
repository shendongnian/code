        public class Genre
        {
            public int GenreId { get; set; }
            public string Name { get; set; }
        
            [NotMapped]
            public List<Album> Albums { get; set; }
        }
