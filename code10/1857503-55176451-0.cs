if (File.Exists(@"Coil master 28-02-2019.csv") == true)
{
    int fileNumber = 0;
    for (; fileNumber < 4; fileNumber++)
    {
        var pgSize = new Rectangle(2976, 4194);
        var pdfdoc = new Document(pgSize); // Setting the page size for the PDF
        pdfdoc.Open(); // Opening the PDF to write the data from the textbox
        foreach (string line in File.ReadLines("Coil master 28-02-2019.csv").Skip(1 + (50 * fileNumber)).Take(50))
        {
            string[] inputArray = line.Split(','); // split the input string by using the delimiter ','
            var COILID = inputArray[0];
            var TYPE = inputArray[1];
            var COLOR = inputArray[2];
            var WEIGHT = Int32.Parse(inputArray[3]);
            var GAUGE = inputArray[4];
            var WIDTH = inputArray[5];
            var p = new Paragraph(COILID + "+" + TYPE + "+" + COLOR + "+" + WEIGHT + "+" + GAUGE + "+" + WIDTH);
            pdfdoc.Add(p);
        }
        pdfdoc.Close();
    }
}
