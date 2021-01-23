    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = FileUpload1.PostedFile.ContentLength != 0;
        }
        private void Save()
        {
            if (Page.IsValid)
            {
                var myFileName = "somefile.jpg"
                FileUpload1.PostedFile.SaveAs(myFileName);
            }
        }
