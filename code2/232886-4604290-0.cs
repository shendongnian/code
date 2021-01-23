    using (var reader = new BinaryReader(File.Open(someFile, FileMode.Open))
    {
        // assuming your string is in plain ASCII encoding:
        var myString = System.Text.Encoding.ASCII.GetString(reader.ReadBytes(30));
        // The rest of the bytes is image data, use an image library to process it
    	var myImage = System.Drawing.Image.FromStream(reader.BaseStream);
    }
