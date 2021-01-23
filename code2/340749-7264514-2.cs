    public int? RelevantTotal
    {
        get
        {
            switch (this.name)
            {
                case "TotalIssues":
                    return this.TotalIssues;
                case "TotalCritical":
                    return this.TotalCritical;
                default:
                    return 0;
            }
        }
    }
