c#
using System.Collections.Generic;
namespace ConsoleApp1
{
    public static class DocumentHandling
    {
        public static List<IAccountable> Documents;
        public static dynamic InternalService { get; set; }
        public static dynamic IRS { get; set; }
        public static void HandleDocuments()
        {
            foreach (var document in Documents)
            {
                document.Account();
            }
        }
    }
    public interface IAccountable
    {
        void Account();
    }
    public abstract class Document
    {
        public int DatabaseId { get; set; }
        public string Title { get; set; }
        
    }
    public abstract class DocumentWithPositions : Document
    {
        public int[] PositionsIds { get; set; }
    }
    public class Invoice : DocumentWithPositions, IAccountable
    {
        public void Account()
        {
            var positions = DocumentHandling.InternalService.PreparePositions(this.PositionsIds);
            DocumentHandling.IRS.RegisterInvoice(positions);
        }
    }
    public class Receipt : DocumentWithPositions, IAccountable
    {
        public void Account()
        {
            Invoice invoice = DocumentHandling.InternalService.ConvertToReceipt(this);
            invoice.Account();
        }
    }
}
See how I can stuff both `Invoice` and `Receipt` documents in single List (because they're downcasted to `IAccountable`)? Now I can account them all at once, even though their concrete implementations handle accounting process differently.
