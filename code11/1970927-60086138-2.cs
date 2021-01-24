    public void PerformWork2(List<Item> items) {
        Task.WhenAll(
            items.Select(item => itemHandler.PerformIndividualWork(item))
            ).Wait(2000);
    }
    // ---- System.Exception : Expected 1 work item running at a time, but got 4
