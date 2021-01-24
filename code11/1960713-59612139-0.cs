    var listOfCurrentFields = wordDoc.Fields;
    
                  ..
                    foreach (Field myMergeField in listOfCurrentFields)
                    {
                        var rngFieldCode = myMergeField.Code;
    
                        var fieldText = rngFieldCode.Text;
    .....
     
    
                        if (fieldText.Contains("MERGEFIELD"))
                        {
    
      			if (fieldName.ToLower().Contains("leftlabel"))
                            {
                                myMergeField.Select();
                                wordApp.Selection.TypeText(LeftLabelText);
                            }
    ....
    
    }
