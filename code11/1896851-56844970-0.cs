    private RenderTexture rt;
    private Texture2D tex;
    private string path;
    
    private void Awake ()
    {
        // Do this only once and keep it around while the game is running
        rt = (RenderTexture) Resources.Load<RenderTexture>(@"Render Texure/ScreenShot");
    
        tex = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
    
        path = Application.persistentDataPath + "Test Shot.png";
    }
    
    private void SaveRTToFileToSharing()
    {
        RenderTexture.active = rt;
        
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        //RenderTexture.active = null;
        tex.Apply();
        byte[] bytes;
        bytes = tex.EncodeToPNG();
       
        // This happens async so your game can continue meanwhile 
        using (var fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            fileStream.WriteAsync(bytes, 0, bytes.Length);
        }
    }
