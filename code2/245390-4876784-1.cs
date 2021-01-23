    public FileResult RepairReport()
    {
        ModelContainer ctn = new ModelContainer();
        List<Title> items = ctn.Items.Where(t => t.RepairSelection == true)
            .Select(t =>t).ToList();
        RepairReporting rtp = new RepairReporting();
        List<long> itemIDs = items.Select(t => t.ItemID).ToList();
        Stream repairReport = rtp.GenerateRepairFile(itemIDs);
        return new FileStreamResult(repairReport, "application/ms-excel")
            {
                FileDownloadName = "RepairReport.xls",
            };
    }
