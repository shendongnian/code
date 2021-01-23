    for (int i = 0; i < images.Length; i++)
    {
        using( var img = Image.FromFile( images[i] ) )
        {
            sha1.ComputeHash(imageToByteArray(img));
        }
        
        sha1codes[i] = Convert.ToBase64String(sha1.Hash);
        Gifs[i] = new GifImages(images[i], sha1codes[i]);
    }
