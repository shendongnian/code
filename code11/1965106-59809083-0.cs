    for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
               {
                   string str1 ="INSERT INTO tbl3(itemnamee,modelnumberr,pricese,countt,totalpricese) VALUES('" + dataGridView2.Rows[i].Cells[1].Value + "','"+ dataGridView2.Rows[i].Cells[2].Value + "','"+ dataGridView2.Rows[i].Cells[3].Value + "','"+ dataGridView2.Rows[i].Cells[4].Value + "','"+ dataGridView2.Rows[i].Cells[5].Value + "'); ";
                   OleDbCommand cmd1 = new OleDbCommand(str1, con);
                   cmd1.ExecuteNonQuery();
               }
