    private List<string> GetTextBoxesAndRadioButtons()
                {
                    var returnList = new List<String>();
                    var textBoxes = new List<string>();
                    var radioButtons = new List<string>();
    
                    foreach (Control ctr in Page.Controls)
                    {
                        
                        if (ctr is TextBox)
                        {
                            textBoxes.Add((ctr as TextBox).Text);  
                        }
    
                        else if (ctr is RadioButton)
                        {
                            radioButtons.Add((ctr as RadioButton).Text);  
                        }
    
                        returnList.AddRange(textBoxes);
                        returnList.AddRange(radioButtons);
                    }
    
                    return returnList;
