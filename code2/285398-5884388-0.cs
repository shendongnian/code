    public class Bib : IBib
    {
        public Bib(int partQty)
        {
            PartQty = partQty;
        }
        public int PartQty { get; private set; }
    }
