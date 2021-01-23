        var list = System.IO.Directory.GetFiles("*.zip");
        foreach (var item in list)
        {
            System.IO.File.Delete(item);
        }
