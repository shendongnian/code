    public class ConsoleReporter : InventoryManagerUpdatedDelegateObject 
    {
        protected override InventoryManagerUpdatedCallbackCore( object sender, InventoryChangeArgs e )
        {
    Console.WriteLine("It was changed by: {0] the {1}",args.Change,args.Pno);
    
        }
    }
