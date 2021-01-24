    public class BusinessAccountMaint_Extension : PXGraphExtension<BusinessAccountMaint>
    {
      public PXAction<BAccount> printAddressLabelNH;
      [PXButton(CommitChanges = true)]
      [PXUIField(DisplayName = "Print Label (NH)")]
      public virtual IEnumerable PrintAddressLabelNH(PXAdapter adapter)
      {
        int? branchID = this.Base.Accessinfo.BranchID;
        Dictionary<string, string> parametersDictionary = new Dictionary<string, string>();
        BAccount bAccount = this.Base.Caches[typeof(BAccount)].Current as BAccount;
        parametersDictionary["BAccount.BAccountID"] = bAccount.BAccountID.ToString();
        CsPrintMaint printMaintGraph = PXGraph.CreateInstance<CsPrintMaint>();
      
        printMaintGraph.PrintReportInDeviceHub("ZRADDRBA", parametersDictionary, "DYMOLBLNH", branchID);
      
        return adapter.Get();
      }
    }
