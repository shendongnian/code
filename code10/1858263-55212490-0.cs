    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MediatR;
    
    namespace imdb_data_retrieval.Models
    {
        public class MovieModel
        {
            public MovieModel(string title, int releaseYear){
                id = Guid.NewGuid();
                Title = title;
                ReleaseYear = releaseYear;
                ImdbId = null;
                QueryDate = DateTime.Now;
            }
            [Key]
            public Guid id { get; set; }
            [ForeignKey("MovieQuery")] //<-- remove this (EF automatically does it at the relationship stuff)
            public Guid RelatedQuery { get; set; } // <-- remove this
            public string Title { get; set; }
            public int ReleaseYear { get; set; }
            public string ImdbId { get; set; }
            public DateTime QueryDate { get; set; }
            //relationship stuff
            public MovieQueryModel MovieQueryModel {get; set;}
            public Guid? MovieQueryModel {get; set;}
        }
    }
