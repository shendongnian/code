     public class DataEditor : System.Web.UI.UpdatePanel, umbraco.interfaces.IDataEditor
        {
           
            public MWCropperDataEditor(umbraco.interfaces.IData Data, string Configuration)
            {
                _data = Data;
    
            }
    
            public virtual bool TreatAsRichTextEditor
            {
                get { return false; }
            }
    
            public bool ShowLabel
            {
                get { return true; }
            }
    
            public Control Editor { get { return this; } }
            
     
            public void Save()
            {
               
                    this._data.Value = "data;
          
            }
    
            protected override void OnInit(EventArgs e)
            {
                
                base.OnInit(e);
    
                imageUpload = new FileUpload();
                imageUpload.ID = "imageUpload";
              
                //shows Image
                cropImage = new System.Web.UI.WebControls.Image();
                cropImage.Width = width;
                cropImage.Height = height;
                cropImage.ImageUrl = this._data.Value.ToString();
              
    
                //Shows dropdown
                locationDropDown = new DropDownList();
                AddItemsToDropDown();
    
                lblInfo = new Label();
                lblInfo.Attributes.Add("id", "title" + base.ClientID);
                lblCropInfo = new Label();
    
                lblCropInfo.Text = "Crop Location: ";
                base.ContentTemplateContainer.Controls.Add(lblInfo);
                base.ContentTemplateContainer.Controls.Add(imageUpload);
                base.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
                base.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
                base.ContentTemplateContainer.Controls.Add(lblCropInfo);
                base.ContentTemplateContainer.Controls.Add(locationDropDown);
                base.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
                base.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
                base.ContentTemplateContainer.Controls.Add(cropImage);
    
    
               
    
            }
    
        }
