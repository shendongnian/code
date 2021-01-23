    public void buttons(object sender, ListViewCommandEventArgs e)
    {
	try {
		switch (e.CommandName) {
			case "Delete":
				//this to take a value from any control
				Label Idlabel = e.Item.FindControl("CatIDLabel");
				Session("ID") = Idlabel.Text();
				break;
			case "new":
				//Show the insert template
				LVCategories.InsertItemPosition = InsertItemPosition.FirstItem;
				break;
			case "Cancel":
				//Hide code
				LVCategories.InsertItemPosition = InsertItemPosition.None;
				break;
			case "Edit":
				//Hide code
				LVCategories.InsertItemPosition = InsertItemPosition.None;
				break;
			case "Update":
				Label PictureIDlbl = LVCategories.EditItem.FindControl("ImageIDLabel");
				//
				FileUpload fu = LVCategories.EditItem.FindControl("FileUpload");
				if (fu.HasFile) {
					string PictureID = PictureIDlbl.Text();
					Session("ImageID") = PictureID.ToString();
					string filepath = Path.Combine(Server.MapPath("~/ADMIN/ImageUpload/Categories/"), PictureID + ".jpg");
					fu.SaveAs(filepath);
				}
				break;
			case "Insert":
				//Uploader Code
				FileUpload fu = LVCategories.InsertItem.FindControl("FileUpload1");
				Images ad = new Images();
				Images.ImagesDataTable dt = default(Images.ImagesDataTable);
				ad.DML("1", null, "Categories", "Category Image");
				dt = ad.Read("3", null, null);
				DataRow DR = dt.Rows(0);
				string Imgid = DR["ImageID"];
				Session("ImageID") = Imgid.ToString();
				if (fu.HasFile) {
					string filepath = Path.Combine(Server.MapPath("~/ADMIN/ImageUpload/Categories/"), Imgid + ".jpg");
					fu.SaveAs(filepath);
				}
				//Hiding the insert template
				LVCategories.InsertItemPosition = InsertItemPosition.None;
				break;
		}
	} catch (Exception ex) {
	}
    }
