    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void GetByteArray();
    #endif
    ...
        
    void CallWebGL()
    {
        GetByteArray();
    }
    void PdfAvailable(string byteArrayStr)
    {
        var byteArray = JsonConvert.DeserializeObject<byte[]>(byteArrayStr);
    }
