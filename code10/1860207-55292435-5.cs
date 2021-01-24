    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; private set; }
        public Genre Genre { get; private set; }
        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; private set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; private set; }
        public DateTime DateAdded { get; private set; }
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; private set; }
        public byte NumberAvailable { get; private set; }
        public void RentOneOut()
        {
           if (NumberInStock <= 0)
              throw new InvalidOperation("Cannot rent out a movie that has no stock.");
           if (NumberAvailable <= 0)
              throw new InvalidOperation("All movie copies are out.");
 
           NumberAvailable -= 1;
        }
        public void ReturnOneIn()
        {
           if (NumberInStock <= 0)
              throw new InvalidOperation("Cannot return a movie that has no stock.");
           if (NumberAvailable >= NumberInStock)
              throw new InvalidOperation("All movie copies are already in. Stocktake needed.");
 
           NumberAvailable += 1;
        }
    }
