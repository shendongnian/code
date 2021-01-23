    // You may try different encodings here (for me it worked with iso-8859-1)
    var encoding = Encoding.GetEncoding("iso-8859-1");
    using (var client = new WebClient())
    {
        using (var stream = client.OpenRead("http://www.maxima.fm/51Chart/"))
        using (var reader = new StreamReader(stream, encoding))
        {
            var result = reader.ReadToEnd();
            Console.WriteLine(result);
        }
    }
