                var s = @"
                    <JamStatus>
    <IPAddress Value=""10.210.104.32 "" FacId=""2"">
    <Type>Letter</Type>
    <JobId>1</JobId>
    <fi>50-30C-KMC-360A</fi>
    <TimestampPrinting>1309464601:144592</TimestampPrinting>
    </IPAddress>
    <IPAddress Value=""10.210.104.32 "" FacId=""2"">
    <Type>Letter</Type>
    <JobId>2</JobId>
    <fi>50-30C-KMC-360A</fi>
    <TimestampPrinting>1309465072:547772</TimestampPrinting>
    </IPAddress> 
    <IPAddress Value=""10.210.104.32 "" FacId=""2"">
    <Type>Letter</Type>
    <JobId>2</JobId>
    <fi>50-30C-KMC-360A</fi>
    <TimestampPrinting>1309465072:547772</TimestampPrinting>
    </IPAddress>  
    </JamStatus>";
                XElement xel = XElement.Parse(s);
                Console.WriteLine(xel.XPathSelectElements("//IPAddress")
                    .GroupBy(el => new Tuple<string, string>(el.Element((XName)"JobId").Value, el.Element((XName)"TimestampPrinting").Value))
                    .Max(g => g.Count())
                );
