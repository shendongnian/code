    public void Main(params object[] args) {
        var passedValues = args.Select(x => x?.ToString() ?? "").ToList();
    
        // Here you have access to user's pasted values...
    
    }
