    using (var r = new ChoXmlReader("*** XML FILE PATH ***")
        .WithXPath("b:MarketingAllCardholderData")
        .WithXmlNamespace("a", "schemas.datacontract.org/2004/07/ExternalClient.Responses")
        .WithXmlNamespace("b", "schemas.datacontract.org/2004/07/ExternalClient.Data.Classes")
        )
    {
        using (var w = new ChoCSVWriter(sb)
            .WithFirstLineHeader()
            .Configure(c => c.UseNestedKeyFormat = false)
            )
            w.Write(r);
    }
    Console.WriteLine(sb.ToString());
