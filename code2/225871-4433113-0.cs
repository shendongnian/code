    string xml = @"<rootNode attib1=""qwerty"" >
    	<subNode1>W</subNode1>
    	<subNode2>X</subNode2>
    	<subNode3>Y</subNode3>
    	<subNode4>Z</subNode4>
    	ABC
    </rootNode>";
    
    var xElement = XElement.Parse(xml);
    xElement.Elements().Remove();
    xElement.Value.Dump();
