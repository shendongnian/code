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
                ex = PXReportRequiredException.CombineReport(ex, null, dictionary);
                object row = PXSelectorAttribute.Select<BAccount.bAccountID>(this.Base.BAccount.Cache, account);
                string text = new NotificationUtility(this.Base).SearchReport(null, row, reportID, branchID);
                //I think you get this problem due to absence of this line
                PrintParameters printParams = new PrintParameters
                {
                    PrintWithDeviceHub = true,
                    DefinePrinterManually = true,
                    PrinterName = "DYMOLABEL"
                };
                dictionary2 = SMPrintJobMaint.AssignPrintJobToPrinter(dictionary2, dictionary, printParams, new NotificationUtility(this.Base).SearchPrinter, null, reportID, reportID, this.Base.Accessinfo.BranchID);
            }
            if (ex != null)
            {
                SMPrintJobMaint.CreatePrintJobGroups(dictionary2);
                throw ex;
            }
            return adapter.Get();
        }
        [Serializable]
        [PXCacheName("Print Parameters")]
        public partial class PrintParameters : IBqlTable, IPrintable
        {
            #region PrintWithDeviceHub
            [PXDBBool]
            [PXDefault(typeof(FeatureInstalled<FeaturesSet.deviceHub>))]
            public virtual bool? PrintWithDeviceHub { get; set; }
            public abstract class printWithDeviceHub : IBqlField { }
            #endregion
            #region DefinePrinterManually
            [PXDBBool]
            [PXDefault(true)]
            public virtual bool? DefinePrinterManually { get; set; }
            public abstract class definePrinterManually : IBqlField { }
            #endregion
            #region PrinterName
            [PXPrinterSelector]
            public virtual string PrinterName { get; set; }
            public abstract class printerName : IBqlField { }
            #endregion
        }  
