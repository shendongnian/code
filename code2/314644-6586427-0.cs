            var transactionList =
                from transactions in root.Elements(XName.Get("Transactions")).Elements().AsEnumerable()
                where transactions.Elements().Any
                    (
                        el =>
                        String.IsNullOrEmpty(el.Value) &&
                        !elementsThatCanBeEmpty.Contains(el.Name)
                    )
                select new { CustomerName = transactions.Element(XName.Get("CustomerName")).Value};
