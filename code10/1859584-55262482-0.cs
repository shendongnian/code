    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        public List<Note> Notes { get; set; }
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
