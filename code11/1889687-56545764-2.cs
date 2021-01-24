    public PXAction<BAccount> PrintAddressLabel;
    [PXButton(CommitChanges = true)]
    [PXUIField(DisplayName = "Print Label")]
    protected virtual IEnumerable printAddressLabel(PXAdapter adapter)
    {
        List<BAccount> list = adapter.Get<BAccount>().ToList<BAccount>();
        int? branchID = this.Base.Accessinfo.BranchID;
        const string reportID = "YOUR_REPORT_ID";
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        Dictionary<string, PXReportRequiredException> dictionary2 = new Dictionary<string, PXReportRequiredException>();
        PXReportRequiredException ex = null;
        foreach (BAccount account in list)
        {
           dictionary["BAccountID"] = account.AcctCD;
           ex = PXReportRequiredException.CombineReport(ex, "ZRCRADDR", dictionary);
           object row = PXSelectorAttribute.Select<BAccount.bAccountID>(this.Base.BAccount.Cache, account);
           string text = new NotificationUtility(this.Base).SearchReport("ZRCRADDR", row, reportID, branchID);
           //I think you get this problem due to absence of this line
           dictionary2 = SMPrintJobMaint.AssignPrintJobToPrinter(dictionary2, dictionary, adapter, new Func<string, string, int?, string>(new NotificationUtility(this.Base).SearchPrinter), "ZRCRADDR", reportID, text, branchID);
         }
         if (ex != null)
         {
             SMPrintJobMaint.CreatePrintJobGroups(dictionary2);
             throw ex;
         }
         return adapter.Get();
     }
