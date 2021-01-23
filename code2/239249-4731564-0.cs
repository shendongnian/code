        string text = "book//title//page/section/para";
        string[] delimiters = { "//", "/" };
        string[] result = text.Split(delimiters,StringSplitOptions.RemoveEmptyEntries);
        System.Diagnostics.Debug.WriteLine(result);
        Assert.IsTrue(result[0].isEqual("book"));
        Assert.IsTrue(result[1].isEqual("title"));
        Assert.IsTrue(result[2].isEqual("page"));
        Assert.IsTrue(result[3].isEqual("section"));
        Assert.IsTrue(result[4].isEqual("para"));
