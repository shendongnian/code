    using System.Diagnostics;
    using System.ComponentModel;
     protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
             GridViewRow row = GridView1.SelectedRow;
    
             string Datalink = row.Cells[2].Text;
             string myPath = @"C:\Users\abc\" + Datalink ;
            Process prc = new Process();
            prc.StartInfo.FileName = myPath;
            prc.Start();
             
        }
