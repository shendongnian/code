    private List<Curve> Curves;
    this.Curves.Sort(new CurveSorter());
    
    public class CurveSorter : IComparer<Curve>
    {
        public int Compare(Curve c1, Curve c2)
        {
            return c2.CreationTime.CompareTo(c1.CreationTime);
        }
    }
