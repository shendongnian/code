    public IEnumerable<Model.PIP> GetPIPs()
    {
        if (Repository.PIPRepository.PIPList == null)
            Repository.PIPRepository.Load();
        return Repository.PIPRepository.PIPList.Skip(Math.Max(0,Repository.PIPRepository.PIPList.Length - 100));
    }
