    switch (imageInfo.Extension.ToUpper())
    {
       case ".JPG": this.UpLoadImageFile(imageInfo); break;
       case ".GIF": this.UpLoadImageFile(imageInfo); break;
       case ".BMP": this.UpLoadImageFile(imageInfo); break;
       default: //Show msg "file type error."; break;
    }
    }
    }
    
    private void UpLoadImageFile(FileInfo info)
    {
         SqlConnection objConn = null;
         SqlCommand objCom = null;
       try
       {
           byte[] content = new byte[info.Length];
           FileStream imagestream = info.OpenRead();
           imagestream.Read(content, 0, content.Length);
           imagestream.Close();
    
           objConn = new SqlConnection(strConnectionString);
           objCom = new SqlCommand("insert into CategoryName,Picture)values(@CategoryName,@Picture)", objConn);
    
           SqlParameter categorynameParameter = new SqlParameter("@CategoryName", SqlDbType.NVarChar);
    if (this.txtFileName.Text.Trim().Equals(""))
        categorynameParameter.Value = "Default";
    else
        categorynameParameter.Value = this.txtFileName.Text.Trim();
    objCom.Parameters.Add(categorynameParameter);
    SqlParameter pictureParameter = new SqlParameter("@Picture", SqlDbType.Image);
    pictureParameter.Value = content;
    objCom.Parameters.Add(pictureParameter);
    
    objConn.Open();
    objCom.ExecuteNonQuery();
    objConn.Close();
    }
    catch (Exception ex)
    {
    throw new Exception(ex.Message);
    }
    finally
    {
    objConn.Close();
    }
    }
