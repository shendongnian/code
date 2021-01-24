            public class Entree
            {
                public string nomentree { get; set; }
                public string descentree { get; set; }
                public string recetteentree { get; set; }
                public string recette { get; set; }
                public string Print(Entree entree)
                {
                    return string.Format("Norm : {0}\nDescription : {1}\n Recette : {2}",
                        entree.nomentree, entree.descentree, entree.recetteentree);
                }
             }
