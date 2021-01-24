    [System.SerializableAttribute]
    public partial class PrintParameters : IBqlTable, PX.SM.IPrintable
    {
      #region PrintWithDeviceHub
      public abstract class printWithDeviceHub : IBqlField { }
            
      [PXDBBool]
      [PXDefault(typeof(FeatureInstalled<FeaturesSet.deviceHub>))]
      [PXUIField(DisplayName = "Print with DeviceHub")]
      public virtual bool? PrintWithDeviceHub { get; set; }
      #endregion
      
      #region DefinePrinterManually
      public abstract class definePrinterManually : IBqlField { }
      [PXDBBool]
      [PXDefault(true)]
      [PXUIField(DisplayName = "Define Printer Manually")]
      public virtual bool? DefinePrinterManually { get; set; }
      #endregion
      
      #region Printer
      public abstract class printerName : PX.Data.IBqlField { }
      
      [PX.SM.PXPrinterSelector]
      public virtual string PrinterName { get; set; }
      #endregion
    }
    public class CsPrintMaint : PXGraph<CsPrintMaint>
    {
      public void PrintReportInDeviceHub(string reportID, Dictionary<string, string> parametersDictionary, string printerName, int? branchID)
      {
        Dictionary<string, PXReportRequiredException> reportsToPrint = new Dictionary<string, PXReportRequiredException>();
        PrintParameters filter = new PrintParameters();
        filter.PrintWithDeviceHub = true;
        filter.DefinePrinterManually = true;
        filter.PrinterName = printerName;
        reportsToPrint = PX.SM.SMPrintJobMaint.AssignPrintJobToPrinter(reportsToPrint, parametersDictionary, filter, 
               new NotificationUtility(this).SearchPrinter, CRNotificationSource.BAccount, reportID, reportID, branchID);
        if (reportsToPrint != null)
        {
          PX.SM.SMPrintJobMaint.CreatePrintJobGroups(reportsToPrint);
        }
      }
    }
