    [TestFixture]
    public class Class1
    {
    
        [Test]
        public void Go()
        {
            var qbItemService = Create(1);
            var qbVendorService = Create(2);
            var qbSalesRecipeService = Create(3);
    
            qbItemService.ShowType();
            qbVendorService.ShowType();
            qbSalesRecipeService.ShowType();
        }
    
        public static qbEntityService Create(int number)
        {
            switch (number)
            {
                case 1:
                    return new QuickbooksItemService().UpdateMozzoEntityWithFinancialsId();
                case 2:
                    return new QuickbooksVendorService().UpdateMozzoEntityWithFinancialsId();
                case 3:
                    return new QuickbooksSalesReceiptServiceAdapter(new QuickbooksSalesReceiptService()).UpdateMozzoEntityWithFinancialsId();
                default:
                    throw new Exception();
            }
        }
    }
    
    public interface IEntityService
    {
        qbEntityService UpdateMozzoEntityWithFinancialsId();
    }
    
    public class qbEntityService
    {
        public string Type { get; set; }
    
        public void ShowType()
        {
            Console.WriteLine(this.Type);
        }
    }
    
    public class QuickbooksItemService : IEntityService
    {
        public qbEntityService UpdateMozzoEntityWithFinancialsId()
        {
            Console.WriteLine("I am QuickbooksItemService, performing UpdateMozzoEntityWithFinancialsId");
            return new qbEntityService() { Type = "QuickbooksItemService" };
        }
    }
    
    public class QuickbooksVendorService : IEntityService
    {
        public qbEntityService UpdateMozzoEntityWithFinancialsId()
        {
            Console.WriteLine("I am QuickbooksVendorService, performing UpdateMozzoEntityWithFinancialsId");
            return new qbEntityService() { Type = "QuickbooksVendorService" };
        }
    }
    
    public class QuickbooksSalesReceiptService
    {
        public qbEntityService UpdateStratusEntityWithFinancialsId()
        {
            Console.WriteLine("I am QuickbooksSalesReceiptService, performing UpdateStratusEntityWithFinancialsId");
            return new qbEntityService() { Type = "QuickbooksSalesReceiptService" };
        }
    }
    
    
    public class QuickbooksSalesReceiptServiceAdapter : IEntityService
    {
        private QuickbooksSalesReceiptService adaptee;
    
        public QuickbooksSalesReceiptServiceAdapter(QuickbooksSalesReceiptService adaptee)
        {
            this.adaptee = adaptee;
        }
    
        public qbEntityService UpdateMozzoEntityWithFinancialsId()
        {
            return adaptee.UpdateStratusEntityWithFinancialsId();
        }
    }
