        public class 
        {
           public Country Country { get; set; }
           [Required]
           public int CountryId { get; set; }
           [Required]
           public int Id { get; set; }
           [Required]
           public string Name { get; set; }
           [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
           public int? ParentId { get; set; }
           [ForeignKey("ParentId")]
           public Company Parent { get; set; }     
        }
        
