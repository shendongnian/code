using System.Linq;
(...)
var lineItems = splitAccount.Select( lineItem =>  new RemitaSplit { ... } ).ToList();
# with `foreach`
var lineItems = new List<RemitaSplit>();
foreach ( var lineItem in splitAccount)
{
   //item, not items
   var lineItem = new RemitaSplit { 
       lineItemsId = lineItem.BursaryPaymentSplittingId.ToString(),
       (...)
   };
   lineItems.Add(lineItem);
}
