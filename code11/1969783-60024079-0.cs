       public class ViewModel
        {
            public List<string> Places { get; set; }
        
            public List<string> MostFavoritePlaces => Places.Take(3).ToList();
        
            public List<string> FavoritePlaces => Places.Skip(3).ToList();
        
            public ViewModel()
            {
                Places = new List<string>{ "AA", "BB", "CC", "DD", "EE", "FF", "GG", "HH", "II", "JJ" };
            }
        }
