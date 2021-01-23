        HttpFileCollection hfc = Request.Files;
        for (int i = 0; i < hfc.Count; i++)
        {
            HttpPostedFile hpf = hfc[i];
            if (hpf.ContentLength > 0)
            {
                hpf.SaveAs(Server.MapPath("MyFiles") + "\\" +
                  System.IO.Path.GetFileName(hpf.FileName));
                Response.Write("<b>File: </b>" + hpf.FileName + " <b>Size:</b> " +
                    hpf.ContentLength + " <b>Type:</b> " + hpf.ContentType + " Uploaded Successfully <br/>");
            }
        }
