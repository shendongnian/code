    public IEnumerable<string> GetAllLogsParallel(IEnumerable<IComputer> computers)
    {
        return computers
            .AsParallel()
            .SelectMany(cpt => cpt.GetLogs());
    }
