      engine = new Engine();
      listDto = engine.ReadHistory(Session["UserID"].ToString());
     
      List<DTO> listDtoNew=new List<DTO>();
      foreach (DTO iterDTO in listDto)
      {
         iterDTO.EncryptedStatusId = Triple.Encrypt(iterDTO.StatusId.ToString());
         listDtoNew.add(iterDTO);
      }
      this.dvHistory.DataSource = listDtoNew;
      this.dvHistory.DataBind();
