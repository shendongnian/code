    var query = QR.ToLookup(i=>i.DeviceName, i => new {i.GroupName, i.PinName})
                  .Select(i=> 
                         new {DeviceName = i.Key, 
                              Groups = i.ToLookup(g=>g.GroupName, g=>g.PinName)});
    
    		var sb = new StringBuilder();
    		foreach ( var device in query)
    		{
    			sb.AppendLine(device.DeviceName);
    			foreach ( var gr in device.Groups)
    			{
    			   sb.Append(gr.Key + ": ");
    			   sb.Append(String.Join(", ", gr.ToArray()));
    			   sb.AppendLine();
    			}
    			sb.AppendLine();
    		}
    		var stringToWrite = sb.ToString();
