    var bytes = File.ReadAllBytes(@"C:\temp\duck.jpg");
    
    var temp = Path.GetTempFileName();
    
    File.WriteAllBytes(temp, bytes);
    
    var img = Image.FromFile(temp);
    
    Console.WriteLine ("width: {0}, height: {0}", img.Width, img.Height);
