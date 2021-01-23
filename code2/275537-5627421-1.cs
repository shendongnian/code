      private List<string> GetTextBoxesAndRadioButtons()
                {
                    var returnList = new List<String>();
                   
                     string txt;
    
                    foreach (Control ctr in Page.Controls)
                    {
                        
                       txt = CallControls(ctr);
                        returnList.Add(txt);
                    }
    
                    return returnList;
                }
    
            private string CallControls(System.Web.UI.Control p)
            {
                string returntext = "";
    
    	        foreach ( Control ctrlMain in p.Controls )
    	        {
    		        if ( ctrlMain.HasControls() )
    		        {
    			        /* Recursive Call */
    			        CallControls(ctrlMain);
    		        }
    		        if ( ctrlMain is TextBox )
    		        {
    			        TextBox txt;
    			        txt = (TextBox)FindControl(ctrlMain.ID);
    			        returntext = txt.Text;
    		        }
                    else  if ( ctrlMain is RadioButton )
    		        {
    			        RadioButton txt;
    			        txt = (RadioButton)FindControl(ctrlMain.ID);
    			        returntext = txt.Text;
    		        }
    	        }	
    		
                return returntext;
            }
