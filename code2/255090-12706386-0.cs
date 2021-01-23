             if (RadioButton1.Checked == true)
            {
                ListBox3.Visible = true;
                int x = GridView1.Rows.Count;
                int o = GridView1.Columns.Count;
                String SearchItem = TextBox1.Text;
                for (int i = 0; i < x; i++)
                {
                    for (int c = 0; c < o; c++)
                    {
                        if (SearchItem == GridView1.Rows[i].Cells[0].Text)
                        {
                            n = GridView1.Rows[i].Cells[1].Text + "  R" + GridView1.Rows[i].Cells[5].Text;
                        }
                    }
                    ListBox3.Items.Add(n);
                }
            }
            else if (RadioButton2.Checked == true)
            {
                ListBox3.Visible = true;
                int x = GridView1.Rows.Count;
                int o = GridView1.Columns.Count;
                String SearchItem = TextBox1.Text;
                for (int i = 0; i < x; i++)
                {
                    for (int c = 0; c < o; c++)
                    {
                        if (SearchItem == GridView1.Rows[i].Cells[3].Text)
                        {
                            count++;
                            for (int a = 0; a < count; a++)
                            {
                                ListBox3.Items.Add(GridView1.Rows[i].Cells[1].Text + "   R" + GridView1.Rows[i].Cells[5].Text);
                            }
                        }
                    }  
                }
            }
        }
