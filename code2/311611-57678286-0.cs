     public class Movie
     {
                public string Name { get; set; }
                public string Description { get; set; }
                public string Classification { get; set; }
                public string Studio { get; set; }
                public DateTime? ReleaseDate { get; set; }
                public List<string> ReleaseCountries { get; set; }
     }
    
     Movie movie = new Movie();
     movie.Name = "Bad Boys III";
     movie.Description = "It's no Bad Boys";
                
     string ignored = JsonConvert.SerializeObject(movie,
                Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
