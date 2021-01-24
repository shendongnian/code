cs
private void UpdateGraphStatistics()
{
    var compdata = new List<double>();
    var dqdata = new List<double>();
    foreach (var item in Competitors)
    {
        if (!item.DQ)
        {
            compdata.Add(item.VIs);
        }
        else if (item.DQ)
        {
            dqdata.Add(item.VIs);
        }
    }
    GraphData = new GraphModel(compdata, dqdata);
}
The problem with this code is that it creates a new object, which actually severs the bindings that the View has with `GraphData`.
I was posed with two options: do not create a new object, or create a new object and then rebind the view to the object.
Because I haven't been able to figure out how to rebind the view nicely, I opted for the option of creating a method within the object to modify the data. I did:
cs
public void ParseData(List<CompetitorModel> compData, List<CompetitorModel> dqData)
{
    CompetitionData.Clear();
    DQData.Clear();
    // Convert competitionData into observable points
    int count = 0;
    foreach (var item in compData)
    {
        CompetitionData.Add(new ObservablePoint(count++, item.VIs));
    }
    // Convert dqdata into observable points
    int offsetX = compData.Count;
    foreach (var item in dqData)
    {
        DQData.Add(new ObservablePoint(offsetX++, item.VIs));
    }
}
In short, I made the section of code that deals with data pasrsing within my object public, which clears the collections within, and <s>constructs a new</s> modifies the existing SeriesCollection which is still bound to the view, without disrupting the bind, by altering the `CompetitionData` and `DQData` collections.
Once I learn how to rebind the data, I *COULD* make this method private and simply create a new object, but then I am also creating the entire SeriesCollection (and other Funcs and stuff I have within the model now) each time, so this method may be theoretically faster process-wise.
