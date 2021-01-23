    public class Images
    {
     string imageFilename = null;
     byte[] imageBytes = null;
     SqlConnection imageConnection = null;
     SqlCommand imageCommand = null;
     SqlDataReader imageReader = null;
     public Images() 
     {
        imageConnection = new SqlConnection("server=      (local)\\SQLEXPRESS;database=MyDatabase;Integrated Security=SSPI");
       imageCommand = new SqlCommand(@"select imagefile, imagedata from imagetable",        imageConnection);
      imageConnection.Open();
      imageReader = imageCommand.ExecuteReader();   }
  
    public Bitmap GetImage() 
    {
      MemoryStream ms = new MemoryStream(imageBytes);
      Bitmap bmap = new Bitmap(ms);
      return bmap;
    }
    public string GetFilename() 
    {
      return imageFilename;
    }
    public bool GetRow() 
    {
      if (imageReader.Read())
     {
        imageFilename = (string) imageReader.GetValue(0);
        imageBytes = (byte[]) imageReader.GetValue(1);
        return true;
     }
     else
     {
        return false;
     }
    }
    public void EndImages() 
    {
      imageReader.Close();
      imageConnection.Close();
    } 
 
