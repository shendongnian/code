    class Program
    {
        static void Main(string[] args)
        {
            Chart c = new Chart();
            c.Series = new Series();
            c.Series.Values = new List<SeriesValue>();
            c.Series.Values.Add(new SeriesValue() { Xid = 0, Text = "Not Submitted: 20" });
            c.Series.Values.Add(new SeriesValue() { Xid = 1, Text = "Submitted: 11" });
            c.Series.Values.Add(new SeriesValue() { Xid = 2, Text = "Rejected: 2" });
            c.Graphs = new Graphs();
            c.Graphs.Add(new Graph());
            c.Graphs[0].Values = new List<GraphValue>();
            c.Graphs[0].Values.Add(new GraphValue() { Xid = 0, Color = "#FF0000", Value = 20 });
            c.Graphs[0].Values.Add(new GraphValue() { Xid = 1, Color = "#00FF00", Value = 11 });
            c.Graphs[0].Values.Add(new GraphValue() { Xid = 2, Color = "#0000FF", Value = 2 });
            c.Graphs.Add(new Graph());
            c.Graphs[1].Values = new List<GraphValue>();
            c.Graphs[1].Values.Add(new GraphValue() { Xid = 0, Color = "#FF0000", Value = 24 });
            c.Graphs[1].Values.Add(new GraphValue() { Xid = 1, Color = "#00FF00", Value = 7 });
            c.Graphs[1].Values.Add(new GraphValue() { Xid = 2, Color = "#0000FF", Value = 4 });
            // Make sure it is Serializable
            Serializer.SerializeToXML<Chart>(c, "chart.xml");
            // Make sure it is Deserializable
            Chart c2 = Serializer.DeserializeFromXML<Chart>("chart.xml");
        }
    }
