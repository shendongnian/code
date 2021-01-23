    try
    {
        MessageBox.Show(dgView1[0,dgView1.CurrentRow.Index].Value.ToString());
    }
    catch
    {
        for (int i = 0; i < dgView1.Rows.Count; i++)
        {
            if (dgView1.Rows[i].Selected) 
            {
               MessageBox.Show(dgView1[0,dgView1.Rows[i].Index].Value.ToString());
               return;
            }     
        }
    }
