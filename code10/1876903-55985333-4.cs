    public abstract class Aliments<T> where T : Aliment
    {
        public Aliments(List<T> alimentList)
        {
            AlimentList = alimentList;
        }
        public List<T> AlimentList { get; private set; }
    }
