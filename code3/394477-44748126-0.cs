    StreamReader sr = new StreamReader(Server.MapPath("~/TrackData/") + Textbox.Text);
    
    string read = sr.ReadLine();
    
    if(read != null)
    {
	    Response.Write(read);
    }
    else
    {
	    Response.Write("nothing to display");
    }
