    using System.ComponentModel.DataAnnotations;
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        [NotMapped]
        public int Track { get; set; }
