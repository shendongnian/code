    public IEnumerable<string> GetAllLogsParallel(IEnumerable<IComputer> computers)
    {
        return computers
            .AsParallel()
            .WithDegreeOfParallelism(4)
            .SelectMany(cpt => cpt.GetLogs());
    }
