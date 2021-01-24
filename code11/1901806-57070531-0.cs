    public class Joueur
        {
            public int ID { get; set; }
    
            [Required, Display(Name = "Nom"), StringLength(30)]
            public string Lastname { get; set; }
    
            [Required, Display(Name = "Prénom"), StringLength(30)]
            public string Firstname { get; set; }
    
            [Required, StringLength(15)]
            public Position Poste { get; set; }
    
            public string Image { get; set; }
        }
    
        public enum Position
        {
            Gardien,
            Défenseur,
            Milieu,
            Attaquant
        }
