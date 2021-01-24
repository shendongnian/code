    namespace FCSL.Models.Match
    {
        public class Team
        {
            ...
            
            [Required, Display(Name = "Joueurs")]
            public List<Joueur.Joueur> ListeJoueurs { get; set; }
        }
    }
