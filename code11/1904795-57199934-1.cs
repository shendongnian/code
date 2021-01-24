    var IstItem = Model.First();
    @foreach (var item in Model)
    {
        // do something with each item
        if (result.Equals(IstItem))
        {
            // do something different with the last item
        }
        else
        {
            // do something different with every item but the last
        }
    }
