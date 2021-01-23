    string imageName = boxPostImage.Text;
    StreamResourceInfo sri = null;
    Uri jpegUri = new Uri(imageName, UriKind.Relative);
    sri = Application.GetResourceStream(jpegUri);
    
    try
    {
        byte[] imageData = new byte[sri.Stream.Length];
        sri.Stream.Read(imageData, 0, System.Convert.ToInt32(sri.Stream.Length));
    
        FacebookMediaObject fbUpload = new FacebookMediaObject
        {
             FileName = imageName,
             ContentType = "image/jpg"
        };
        fbUpload.SetValue(imageData);
                    
    
        IDictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("access_token", _AccessToken);
        parameters.Add("source", fbUpload);
    
        //_fbClient.PostAsync("/"+MainPage._albumId+"/photos", parameters);
        _fbClient.PostAsync("/me/photos", parameters);
    
    
        MessageBox.Show("Image has been posted successfully..");
    }
    catch (Exception error)
    {
        MessageBox.Show("Sorry, there's an error occured, please try again.");
    }
