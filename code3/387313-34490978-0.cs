    [Test]
    public void DecimalFormatTests()
    {
        var amt1 = 1000000m;
        var amt2 = 1000000.10m;
        var format = "0.#";
        Console.WriteLine(amt1.ToString("\\£0,0.#"));
        Console.WriteLine(amt2.ToString("\\£0,0.#"));
    }
