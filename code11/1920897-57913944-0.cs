    [Table("Profil")]
    public class Profil
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CodeUtilisateur")]
        [MaxLength(25)]
        public string UtilisateurId { get; set; }
    
        public string Nom { get; set; }
    
        public string Prenom { get; set; }
    
        public virtual User User { get; set; }
    }
    
    [Table("vwADUser")]
    public class User
    {
        [Key]
        [ForeignKey("Profil")]
        public string UserName { get; set; }
    
        [Column("Mail")]
        public string Email { get; set; }
        
        public virtual Profil Profil {get;set;}
    }
