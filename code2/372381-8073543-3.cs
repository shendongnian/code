    public class InvoiceAction : IAction
    {
         public string Name { get { return "Invoicing"; } }
         public void Perform()
         {
             /* Invoice somebody! */
         }
         public InvoiceAction(/* Some pertinent details*) { }
    }
