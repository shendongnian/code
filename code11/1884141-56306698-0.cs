    public class Bibliotikarie
    {
        private List<Bok> Böcker = new List<Bok>();
        
        // This method adds a Bok instance or a derived one to your list
        public void AddBok(Bok b)
        {
            Böcker.Add(b);
        }
        
        public void VisaBöcker()
        {
            foreach (Bok item in Böcker)
            {
                Console.WriteLine($"\r\n\"{item.Titel}\" av {item.Skribent}. År {item.UtÅr}.  ( {item.Typ} )\r\n");
            }
        }
    }
    public class Bok
    {
        public string Titel;
        public string Skribent;
        public string Typ;
        public int UtÅr;
    }
    
    public class Roman : Bok
    {
        public Roman(string _Titel, string _Skribent, int _UtÅr)
        {
            Titel = _Titel;
            Skribent = _Skribent;
            UtÅr = _UtÅr;
            base.Typ = "Roman";
        }
    }
