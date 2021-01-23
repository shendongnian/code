            if(rtbCaseContent.SelectedText.Length > 0 ) 
			{
				// calculate font style 
				FontStyle style = FontStyle.Underline;
				Font selectedFont = rtbCaseContent.SelectionFont;
				if (rtbCaseContent.SelectionFont.Bold == true)
				{
					style |= FontStyle.Bold;
				}
				if (rtbCaseContent.SelectionFont.Italic == true)
				{
					style |= FontStyle.Italic;
				}
				
				rtbCaseContent.SelectionFont = new Font(selectedFont,style);
			}			
