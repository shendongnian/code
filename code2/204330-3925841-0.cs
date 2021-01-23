    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
         sdsFiles.SelectedIndex = e.RowIndex;         
         string fileName = sdsFiles.SelectedRow.Cells[1].Text;
         System.IO.File.Delete(Server.MapPath("") + "\\" + fileName);    
    
         int Fid = (int)GridView1.DataKeys[e.RowIndex].Value;
         sdsFiles.DeleteCommand = "Delete from Files where Fid = @id";
         sdsFiles.DeleteParameters.Clear();
         sdsFiles.DeleteParameters.Add("id",Fid.ToString());
         sdsFiles.Delete();
         
         sdsFiles.SelectedIndex = -1;
    }
