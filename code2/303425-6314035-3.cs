    var xml = @"
        <root>
        <span name=""foo"">
            <span name=""bar"">
                Missing Data
            </span>
        </span>
        <span name=""foo"">
            <span name=""bar"">
                <span name=""detail1"">first detail</span>
                <span name=""detail2"">second detail</span>
            </span>
        </span>
        </root>
    ";
    var document = XDocument.Parse(xml);
    var details = document.XPathSelectElements("//span[@name='foo']/span[@name='bar']/span[starts-with(@name,'detail')]")
        .Select(arg => arg.Value)
        .ToList();
