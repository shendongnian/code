    var transactionList =
         root
        .Elements(XName.Get("Transactions")) //Get <Transaction> elements
        .Elements() //Get <Txn> elements
        .Where(txn => txn.Elements().Any(e => e.Value == String.Empty))  //Filter <Txn> Elements if it have any element like this: <CustomerStreet2></CustomerStreet2>
        .Select(x => new {
            PropertyX = x.Element(XName.Get("UserName")).Value,
            PropertyY = x.Element(XName.Get("CustomerStreet")).Value,
                        ...
        });
