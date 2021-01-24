c#
myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
myWordDoc.Activate();
try
{
	foreach (DataGridViewRow selectedRow in dataGridView2.Rows)
	{
		string Column1 = selectedRow.Cells[0].Value.ToString();
		string Column2 = selectedRow.Cells[1].Value.ToString();
		string Column3 = selectedRow.Cells[2].Value.ToString();
		string Column4 = selectedRow.Cells[3].Value.ToString();
		string Column5 = selectedRow.Cells[4].Value.ToString();
		string Column6 = selectedRow.Cells[5].Value.ToString();
		string Column7 = selectedRow.Cells[6].Value.ToString();
		string Column8 = selectedRow.Cells[7].Value.ToString();
		string Column9 = selectedRow.Cells[8].Value.ToString();
		string Column10 = selectedRow.Cells[9].Value.ToString();
		string Column11 = selectedRow.Cells[10].Value.ToString();
		string Column12 = selectedRow.Cells[11].Value.ToString();
		string Column13 = selectedRow.Cells[12].Value.ToString();
		string Column14 = selectedRow.Cells[13].Value.ToString();
		string Column15 = selectedRow.Cells[14].Value.ToString();
		string Column16 = selectedRow.Cells[15].Value.ToString();
		string Column17 = selectedRow.Cells[16].Value.ToString();
		string Column18 = selectedRow.Cells[17].Value.ToString();
		string Column19 = selectedRow.Cells[18].Value.ToString();
		string Column20 = selectedRow.Cells[19].Value.ToString();
		string Column21 = selectedRow.Cells[20].Value.ToString();
		this.FindAndReplace(wordApp, "<Type1>", Column1);
		this.FindAndReplace(wordApp, "<Type2>", Column2);
		this.FindAndReplace(wordApp, "<Type3>", Column3);
		this.FindAndReplace(wordApp, "<Type4>", Column4);
		this.FindAndReplace(wordApp, "<Type5>", Column5);
		this.FindAndReplace(wordApp, "<Type6>", Column6);
		this.FindAndReplace(wordApp, "<Type7>", Column7);
		this.FindAndReplace(wordApp, "<Type8>", Column8);
		this.FindAndReplace(wordApp, "<Type9>", Column9);
		this.FindAndReplace(wordApp, "<Type10>", Column10);
		this.FindAndReplace(wordApp, "<Type11>", Column11);
		this.FindAndReplace(wordApp, "<Type12>", Column12);
		this.FindAndReplace(wordApp, "<Type13>", Column13);
		this.FindAndReplace(wordApp, "<Type14>", Column14);
		this.FindAndReplace(wordApp, "<Type15>", Column15);
		this.FindAndReplace(wordApp, "<Type16>", Column16);
		this.FindAndReplace(wordApp, "<Type17>", Column17);
		this.FindAndReplace(wordApp, "<Type18>", Column18);
		this.FindAndReplace(wordApp, "<Type19>", Column19);
		this.FindAndReplace(wordApp, "<Type20>", Column20);
		this.FindAndReplace(wordApp, "<Type21>", Column21);
        //Saving file
	    myWordDoc.SaveAs(SaveAs.ToString() + selectedRow.ToString() + ".docx",         ref missing, ref missing, ref missing,
	    ref missing, ref missing, ref missing,
	    ref missing, ref missing, ref missing,
	    ref missing, ref missing, ref missing,
	    ref missing, ref missing, ref missing);     
	}
	
}
catch (Exception ex)
{
	MessageBox.Show("Error : " + ex.Message);
}
