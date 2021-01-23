    private var workUnits = new List<WorkUnit>();
    
    private void ExecuteWorkUnit(int id) {
        var unit = GetWorkUnit(id);
        foreach (var url in unit.URLs) {
             string html = GetContent(url);
             // do whatever else...
             lock (workUnits) unit.Processed++;
        }
    }
    public WorkUnit GetWorkUnit(int id) {
        lock (workUnits) {
             // Left as an exercise for the reader
        }
    }
