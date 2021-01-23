    class CustomOrder : IComparer<Series>
    {
        static readonly Dictionary<string, int> dictionary = 
            new Dictionary<string, int>() 
        { 
            {"Excellent", 1}, 
            {"Very Good", 2},
            {"Average", 3},
            {"Bad", 4},
            {"Very Bad", 5}
        };
        public int Compare(Series x, Series y)
        {
            return dictionary[x.Name].CompareTo(dictionary[y.Name]);
        }
    }
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Series[] sortedSeries = chart.Series.ToArray();
            Array.Sort(sortedSeries, new CustomOrder());
        } 
    }
