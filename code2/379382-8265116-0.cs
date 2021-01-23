            RadioButton rb = new RadioButton();            
            foreach (TableRow tr in QuestionTable.Controls)
            {
                foreach (TableCell tc in tr.Controls)
                {
                    if (tc.Controls[0] is RadioButton)
                    {
                        rb = (RadioButton)tc.Controls[0];
                        if (rb.Checked)
                        {
                            string aa = rb.ID;
                        }
                        break;
                    }
                }               
            }
