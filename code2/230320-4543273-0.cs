    PdfDocument doc = new PdfDocument();
    string mail = textBox1.Text;
    string[] split = mail.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    int counter = split.Count();
    // Source must be array or IList.
    var source = Enumerable.Range(0, 100000).ToArray();
    // Partition the entire source array.
    var rangePartitioner = Partitioner.Create(0, counter);
    double[] results = new double[counter];
    PdfPage[] pages = new PdfPage[counter];
    for (int i = 0; i < counter; ++i) 
    {
        pages[i] = doc.AddPage();
    }
    // Loop over the partitions in parallel.
    Parallel.ForEach(rangePartitioner, (range, loopState) =>
    {
        // Loop over each range element without a delegate invocation.
        for (int i = range.Item1; i < range.Item2; i++)
        {
            f_prime = split[i].Replace(" " , "");
            PdfPage page = pages[i];
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XImage image = XImage.FromFile(f_prime);
            double x = 0;
            gfx.DrawImage(image, x, 0);
        }
    });
