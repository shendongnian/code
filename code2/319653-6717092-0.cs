    protected void frmAsset_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
       if (dosya.HasFile)
        {
           dosya.SaveAs(Server.MapPath("~/img/") + dosya.FileName);
           e.Values["URL"] = "img/" + dosya.FileName;
        }
     }
