        public class UserForRecipeDto
    {
     public ICollection<RecipeForListDto> Recipes {get; set;}
    }
}
       public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created {get; set;}
        public DateTime LastActive {get; set;}
        public string Introduction { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<UserPhoto> UserPhotos {get; set;}
        public ICollection<Recipe> Recipes {get; set;}
    }
