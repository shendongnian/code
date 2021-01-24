    private async Task DoSomethingAsync()
    {
        var tasks = new List<Task>();
        ...
        tasks.Add(DoSomtehingAwsomeAsync(list1));
        tasks.Add(DoSomtehingAwsomeAsync(list2));
        await Task.WhenAll(tasks);
    }
    ...
    private async Task ChangeText(List<Control> lst)
    {           
        // Awesome IO bound work here
        // await CallDataBaseAsync();
        // await VisitGrandMotherAsync();
 
        foreach (var ctrl in lst)
        {
            ctrl.Text = "22";
        }            
    }
