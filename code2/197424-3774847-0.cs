    using(Image image1 = Image.FromFile("c:\\test.jpg"))
    {
        image1.Save("c:\\test2.jpg");
    }
    System.IO.File.Delete("c:\\test.jpg");
    System.IO.File.Move("c:\\test2.jpg", "c:\\test.jpg");
