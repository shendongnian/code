    async Task<int> GetRetirementsAsync(){...}
    async Task<Tuple<int, int, int, int>> CheckStatusAsync()
    {
         ...
         int retired = await GetRetirementsAsync();
         return new Tuple...
    }
    async Task GetCheckStatusAsync()
    {
        var tuple = await CheckStatusAsync();
        // process output:
        LblOut.Text = tuple.Item1.ToString();
        LblStage.Text = tuple.Item2.ToString();
        LblRetired.Text = tuple.Item3.ToString();
        LblStop.Text = tuple.Item4.ToString();
    }
