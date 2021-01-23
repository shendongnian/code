	var tIndex = 1;
	var tCount = oDoc.Tables.Count;
	var tblData = oDoc.Tables[tIndex].Cell(1, 1).Range.Text;
	var pCount = oDoc.Paragraphs.Count;
	var prevPara = "";
	for (var i = 1; i <= pCount; i++) {
		var para = oDoc.Paragraphs[i];
		var paraData = para.Range.Text;
		
		if (paraData == tblData) {
			// this paragraph is at the beginning of the table, so grab previous paragraph
			Console.WriteLine("Header: " + prevPara);
			tIndex++;
			if (tIndex <= tCount)
				tblData = oDoc.Tables[tIndex].Cell(1, 1).Range.Text;
			else
				break;
		}
		prevPara = paraData;
	}
