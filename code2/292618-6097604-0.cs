     protected void lnkbtnDelete_Click(object sender, EventArgs e)
            {
             
                int counter = 0;
                List<string> words = new List<string>();
                foreach (GridViewRow rowitem in grdlistWord.Rows)
                {
                    if (((CheckBox)rowitem.Cells[0].FindControl(""chkWord"")).Checked == true)//i consider that the check box is in the first column index ---> 0
                    {
                        counter++;
                        words.Add(rowitem.Cells[1].Text); //i consider that the word is in the second column index ---> 1
                    }
                }
                /////////////////////////////////////////////////////////////
                if(counter == 0) //no checks
                {
                   
                 //show some message box to clarify that no row has been selected.
    
                }
                /////////////////////////////////////////////////////////////
                if (counter == 1) //one check
                {
                      
                    DeleteRecord(words[0]);
                    //Show some message box to clarify that the operation has been executed successfully.
                   
                }
                /////////////////////////////////////////////////////////////
                if (counter > 1) //more than one check
                {
                    for(int i=0; i<words.Count;i++)
                       {
                         DeleteRecord(words[i]);
                       }
                       //Show some message box to clarify that the operation has been executed successfully.
                }
    
                grdlistWord.DataBind();
            }
