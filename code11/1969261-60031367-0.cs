    [DisplayName("Installation date, from")]
    public string InstallationDateFrom { get; set; }
    [DisplayName("Installation date, to")]
    public string InstallationDateTo { get; set; }
--
    Machines = Machines.Where(x => x.InstallationDate != null && x.InstallationDate >= DateTime.Parse(MachineFilter.InstallationDateFrom)).ToList();
