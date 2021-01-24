       [TestFixture]
        public class Class1
        {
    
            [Test]
            public void Go()
            {
                var qbItem = Export(1);
                var qbVendor= Export(2);
                var qbSales= Export(3);
            }
    
            public qbEntityService Export(int number)
            {
                var qb = Class1.Create(number);
                return qb.UpdateMozzoEntityWithFinancialsId();
            }
    
            public static IEntityService Create(int enumDataElement)
            {
                switch (enumDataElement)
                {
                    case 1:
                        return new QuickbooksItemService();
                    case 2:
                        return new QuickbooksVendorService();
                    case 3:
                        return new QuickbooksSalesReceiptServiceAdapter(new QuickbooksSalesReceiptService());
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
        }
    
        public class QuickbooksItemService : IEntityService
        {
            public qbEntityService UpdateMozzoEntityWithFinancialsId()
            {
                Console.WriteLine("I am QuickbooksItemService, performing UpdateMozzoEntityWithFinancialsId");
                return new qbEntityService();
            }
        }
    
        public class QuickbooksVendorService : IEntityService
        {
            public qbEntityService UpdateMozzoEntityWithFinancialsId()
            {
                Console.WriteLine("I am QuickbooksVendorService, performing UpdateMozzoEntityWithFinancialsId");
                return new qbEntityService();
            }
        }
    
        public class QuickbooksSalesReceiptService
        {
            public qbEntityService UpdateStratusEntityWithFinancialsId()
            {
                Console.WriteLine("I am QuickbooksSalesReceiptService, performing UpdateStratusEntityWithFinancialsId");
                return new qbEntityService();
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
