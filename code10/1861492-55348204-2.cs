    var activepage = Request.RawUrl;
            if (activepage.Contains("?noh2"))
        {
            h2IFrame.Visible = false;
        }
        else
            h2IFrame.Visible = true;
