        //Video relevant int's
    int width {get; set;}
    int height { get; set; }
    //Video relevant text's
    string overskrift { get; set; }
    string poster { get; set; }
    string titleimg { get; set; }
    string ogv { get; set; }
    string mp4 { get; set; }
    string webm { get; set; }
    string reso { get; set; }
    string res { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    //low 240i resolution player LowD
    protected void low240i_Click(object sender, EventArgs e)
    {
        height = 480;
        width = 640;
        reso = "240i";
        if (reso == "240i")
            res = "240i/";
        else if (reso == "240p")
            res = "240p/";
        else if (reso == "480p")
            res = "480p/";
        else if (reso == "720p")
            res = "720p/";
        int Data = Convert.ToInt32(Request.QueryString["id"]);
        VideoDataContext db = new VideoDataContext();
        var fetch = from list in db.VideoDBs
                    where
                    list.VidID == Data
                    select list;
        foreach (var list in fetch)
        {
            overskrift = "\"" + list.Name + "\"";
            poster = "\"" + list.IMGAddr + "\"";
            titleimg = "\"" + list.IMGAddr + "\"";
            if (list.mp4 == true)
                mp4 = "\"" + "../Movies/Mov/" + res + list.VIDAddr + ".mp4" + "\"";
            else
                mp4 = null;
            if (list.ogv == true)
                ogv = "\"" + "../Movies/Mov/" + res + list.VIDAddr + ".ogv" + "\"";
            else
                ogv = null;
            if (list.webm == true)
                webm = "\"" + "../Movies/Mov/" + res + list.VIDAddr + ".webm" + "\"";
            else
                webm = null;
        }
        Panel1.Controls.Add(new LiteralControl("<div class=player ><br />"));
        Panel1.Controls.Add(new LiteralControl("<h3>" + overskrift + " in " + reso + "</h3><br /><br />"));
        Panel1.Controls.Add(new LiteralControl("<video controls=controls id=video width=" + "\"" + width + "\"" + " height=" + "\"" + height + "\"" + " poster=" + poster + " preload=auto >"));
        Panel1.Controls.Add(new LiteralControl("<source src=" + mp4 + " type=\"video/mp4; codecs=avc1.42E01E, mp4a.40.2\" title=" + titleimg + " />"));
        Panel1.Controls.Add(new LiteralControl("<source src=" + webm + " type=\"video/webm; codecs=vp8, vorbis\" title=" + titleimg + " />"));
        Panel1.Controls.Add(new LiteralControl("<source src=" + ogv + " type=\"video/ogg; codecs=theora, vorbis\" title=" + titleimg + " />"));
        Panel1.Controls.Add(new LiteralControl("Your browser does not support the video tag."));
        Panel1.Controls.Add(new LiteralControl("</video></div>"));
    }
