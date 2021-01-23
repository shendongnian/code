    string xmlText = @"<Root>
                        <Header>
                            <value1>0000000</value1>
                            <value2>1</value2>
                            <value3>100.00</value3>
                        </Header>
                        <Transactions>
                            <Txn>
                                <id>1</id>
                                <UserName>BSmith</UserName>
                                <CustomerFirst>Bob</CustomerFirst>
                            </Txn>
                            <Txn>
                                <id></id>
                                <UserName>NSmith</UserName>
                                <CustomerFirst></CustomerFirst>
                            </Txn>
                        </Transactions>
                        </Root>";
    var root = XElement.Parse(xmlText);
    var transactionsWithoutCustomerFirst =
        from transactions in root.Elements(XName.Get("Transactions")).Elements()
        where transactions.Elements().Any(el => String.IsNullOrEmpty(el.Value))
        select transactions;
    foreach(var t in transactionsWithoutCustomerFirst)
    {
        Console.WriteLine(t.Element(XName.Get("UserName")).Value);
    }
