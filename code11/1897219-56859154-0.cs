    var workflowXml = @"
        <Properties>
            <prop1 Name = ""Apple"" Defaultvalue=""red"">
                <childprop Name = ""special"" Value=""pink"" >
                </childprop>
            </prop1>
            <prop1 Name = ""Orange""  Defaultvalue=""orange"">     
            </prop1>
            <prop1 Name = ""Banana"" Defaultvalue=""yellow"">
                <childprop Name = ""raw"" Value=""green"" >
                </childprop>
                <childprop Name = ""special"" Value=""red"" >
                </childprop>
            </prop1>  
        </Properties>";
    
    var xmlDoc = XDocument.Parse(workflowXml);
    var xmlCurrentLevelElement = xmlDoc.Element("Properties");
    var stepNumber = 1;
    
    while (true)
    {
        var options = xmlCurrentLevelElement
            .Elements()
            .Select(e => e.Attributes().FirstOrDefault(a => a.Name == "Name"))
            .Where(a => a != null)                    
            .ToArray();
    
        if (!options.Any())
        {
            var currentValue = xmlCurrentLevelElement
                .Attributes()
                .FirstOrDefault(a => a.Name == "Value" || a.Name == "Defaultvalue")
                ?.Value ?? "value not defined";
    
            Console.WriteLine($"no more options: {currentValue}");
            break;
        }
    
        var hints = string.Join(" or ", options.Select(a => a.Value));
    
        Console.WriteLine($"step {stepNumber}: input any value from '{hints}' - ");
        var value = Console.ReadLine();
    
        var xmlNextLevelElement = options
            .FirstOrDefault(a => a.Value == value)
            ?.Parent ?? null;
    
        if (xmlNextLevelElement == null)
        {
            var defaultValue = xmlCurrentLevelElement
                .AncestorsAndSelf()
                .Select(e => e.Attributes().FirstOrDefault(a => a.Name == "Defaultvalue"))
                .Where(a => a != null)
                .FirstOrDefault()
                ?.Value ?? "default value not defined";
    
            Console.WriteLine($"no match: {defaultValue}");
            break;
        }
    
        xmlCurrentLevelElement = xmlNextLevelElement;
        stepNumber++;
    }
