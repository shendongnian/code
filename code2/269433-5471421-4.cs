     protected void Button1_Click(object sender, EventArgs e)
        {
        FileInfo imageInfo = new FileInfo(File1.Value.Trim());
        
        if (!imageInfo.Exists)
            //Show msg for "please select one image file."
          else
          {
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
               objCom = new SqlCommand("insert into TableName(FieldName,Picture)values(@FieldName,@Picture)", objConn);
     SqlParameter FieldNameParameter = new SqlParameter("@FieldName", SqlDbType.NVarChar);
     if (this.txtFileName.Text.Trim().Equals(""))
     FieldNameParameter.Value = "Default";
     else
      FieldNameParameter.Value = this.txtFileName.Text.Trim();
      objCom.Parameters.Add(FieldNameParameter);
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
