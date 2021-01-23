    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int Fid = (int)GridView1.DataKeys[e.RowIndex].Value;
        sdsFiles.DeleteCommand = "Delete from Files where Fid = @id";
        sdsFiles.DeleteParameters.Clear();
        sdsFiles.DeleteParameters.Add("id",Fid.ToString());
        sdsFiles.Delete();
        string fileName = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label1")).Text;
        System.IO.File.Delete(Server.MapPath("") + "\\" + fileName);
    }
        
