    [DataMember]
    public Image OntwerpImageImage
    {
        get { return ConvertByteArrayToImage(OntwerpImage); }
        set { OntwerpImage = ConvertImageToByteArray(value); }
    }
    
    //[DataMember]
    public byte[] OntwerpImage { get; set; }
    
    public Image ConvertByteArrayToImage(Byte[] bytes)
    {
        var memoryStream = new MemoryStream(bytes);
        var returnImage = Image.FromStream(memoryStream);
        return returnImage;
    }
    
    public Byte[] ConvertImageToByteArray(Image image)
    {
        var memoryStream = new MemoryStream();
        image.Save(memoryStream, ImageFormat.Jpeg);
        return memoryStream.ToArray();
    }
