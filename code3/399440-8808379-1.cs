    using System.Threading.Tasks;
    var results = new List<string>();
    Parallel.ForEach(myList, value =>
    {
        string result = TimeConsumingTask(value);
        results.Add(result);
    });
    //update UI
    listBox.AddRange(results);
