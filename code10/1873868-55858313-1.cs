    public virtual ICollection<User> Users { get; set; } = new List<User>();
    [NotMapped]
    public User Pilote
    {
       get { return Users.SingleOrDefault(u => u.IsPilote); }
       set 
       {   
          var newPilote = Users.Single(u => u.UserId == value.UserId); // Ensure the user nominated for Pilote is associated with this Promotion.
          var existingPilote = Pilote;
          if (existingPilote != null)
              existingPilote.IsPilote = false;
          newPilote.IsPilote = true;
       }
    }
