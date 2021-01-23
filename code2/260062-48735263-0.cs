     public string Response { get; set; }
     private void OkButton_Click(object sender, EventArgs e)
     {
        Response = "ok";
     }
    
     private void CancelButton_Click(object sender, EventArgs e)
     {
        Response = "Cancel";
     }
