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
                                <id>2</id>
                                <UserName>NSmith</UserName>
                                <CustomerFirst></CustomerFirst>
                            </Txn>
                            <Txn>
                                <id></id>
                                <UserName>JSmith</UserName>
                                <CustomerFirst>James</CustomerFirst>
                            </Txn>
                            <Txn>
                                <id>4</id>
                                <UserName>KSmith</UserName>
                                <CustomerFirst>Kevin</CustomerFirst>
                                <AddressTwo></AddressTwo>
                            </Txn>
                        </Transactions>
                        </Root>";
    var root = XElement.Parse(xmlText);
        var elementsThatCanBeEmpty = new HashSet<XName>
                                         {
                                             XName.Get("AddressTwo")
                                         };
        var transactionsWithoutCustomerFirst =
            from transactions in root.Elements(XName.Get("Transactions")).Elements()
            where transactions.Elements().Any
                (
                    el =>
                    String.IsNullOrEmpty(el.Value) &&
                    !elementsThatCanBeEmpty.Contains(el.Name)
                )
            select transactions;
    foreach(var t in transactionsWithoutCustomerFirst)
    {
        Console.WriteLine(t.Element(XName.Get("UserName")).Value);
    }
