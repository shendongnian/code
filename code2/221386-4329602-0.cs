    for (int i = 0; i < 10; i++)
                {
                    RadioButton rb = new RadioButton();
                    rb.ID = "rb"+i;
                    rb.GroupName="rbGroup";
                    GridView1.Rows[i].Cells[3].Controls.Add(rb);
                }
