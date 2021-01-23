    public class User
    {
        public static User Create(Action<User> init)
        {
            var user = new User();
            user.Guid = Guid.NewGuid();
            user.Since = DateTime.Now;
            init(user);
            return user;
        }
        public int UserID { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Widget> Widgets { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
        [StringLength(255), Required]
        public string Password { get; set; }
        [StringLength(16), Required]
        public string Salt { get; set; }
        public DateTime Since { get; private set; }
        public Guid Guid { get; private set; }
    }
