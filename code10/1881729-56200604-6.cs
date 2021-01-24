    {
        if (AjaxFileUpload1.HasAttributes)
        {
    
            string fileName = Path.GetFileName(e.FileName);
            string extension = Path.GetExtension(e.FileName);
            AjaxFileUpload1.SaveAs(Server.MapPath("~/Wishlist/" + fileName));
            String CS = ConfigurationManager.ConnectionStrings["BudgetDBConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("insert into ImaginiWishlist(Nume,Extensie,DorintaId) values(@Nume,@Extensie,@DorintaId);", con);
    
    
                SqlDataAdapter sda = new SqlDataAdapter();
    
                cmd.Parameters.AddWithValue("@Nume", fileName);
                cmd.Parameters.AddWithValue("@Extensie", extension);
                cmd.Parameters.AddWithValue("@DorintaId", dorintaId);
    
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
