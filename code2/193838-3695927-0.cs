    public class NoteChart
    {
      public SimFile Owner {get; private set;}
      public string Id { get; private set; }
      internal NoteChart(SimFile owner, string id)
      {
        this.Owner = owner;
        this.Id = id;
        Owner.Add(id, this);
      }
    }
    public class SimFile : Dictionary<string, NoteChart>
    {
      public NoteChart CreateNoteChart(string id)
      {
        NoteChart noteChart = new NoteChart(this, id);
        return noteChart;
      }
    }
