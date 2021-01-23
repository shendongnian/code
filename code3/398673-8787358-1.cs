    // /Gallery/Upload
            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Upload()
            {
                ...
                HttpPostedFileBase postedFile = Request.Files["file"];
                        
    			if (postedFile != null)
    			{
    				string filename = Path.GetExtension(postedFile.FileName);
    				Stream stream = postedFile.InputStream;
    				long length = stream.Length;
    				vo.image = new byte[(int)length];
    				stream.Read(vo.image, 0, (int)length);
    				stream.Close();
    			}
    			...
            }
