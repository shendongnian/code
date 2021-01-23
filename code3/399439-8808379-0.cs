    using System.Threading.Tasks;
    Parallel.ForEach(myList, value =>
    {
        string result = TimeConsumingTask(value);
        //update UI
        listBox.Add(result);
    });
