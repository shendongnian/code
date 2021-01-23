    LinkButton btnSave = new LinkButton(); 
    btnSave.ID = Guid.NewGuid().ToString();  
    btnSave.Attributes.Add("runat", "server"); 
    btnSave.Click += new EventHandler(btnSave_Click); 
    Image img = new Image();
    img.ImageUrl = "someimage.png";
    btnSave.Controls.Add(img);
    PlhControl.Controls.Add(btnSave); 
    
    
