    //check for SmartArt
    if(_shape.HasSmartArt == MsoTriState.msoTrue) {
    	foreach( SmartArtNode node in _shape.SmartArt.AllNodes) {
    		var txtRange = node.TextFrame2.TextRange;
    		var txt = txtRange.Paragraphs.Text.Split(new string[] { "\r" }, StringSplitOptions.None);
    
    		foreach(string line in txt) 
    			Console.WriteLine(line);
    	}
    }
