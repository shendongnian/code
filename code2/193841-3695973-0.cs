    public class Simfile
    {
       public Simfile()
       {
          Notecharts = new List<Notechart>();
       }
       public List<Notechart> Notecharts { get; private set; }
    }
    public class Notechart
    {
       public Notechart(Simfile simfile)
       {
          Simfile = simfile;
          simfile.Notecharts.Add(this);
       }
       public Simfile Simfile { get; private set; }
    }
