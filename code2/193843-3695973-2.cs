    public class Simfile
    {
       public Simfile()
       {
          ChildNotecharts = new List<Notechart>();
       }
       private List<Notechart> ChildNotecharts { get; set; }
       public IEnumerable<Notechart> Notecharts
       {
          get { return ChildNotecharts; }
       }
       public int AddNotechart(Notechart notechart)
       {
          if (ChildNotecharts.Contains(notechart)) return 0;
          if (notechart.Simfile != this) return -1;
          ChildNotecharts.Add(notechart);
          return 1;
       }
    }
    public class Notechart
    {
       public Notechart(Simfile simfile)
       {
          Simfile = simfile;
          simfile.AddNotechart(this);
       }
       public Simfile Simfile { get; private set; }
    }
