    class ImageData
    {
        public int[] FlatImate { get; }
        public int Number { get; }
    
        public ImageData(int[] flatImage, int number)
        {
            FlatImage = flatImage;
            Number = number;
        }
    }
    
    static ImageData[] CreateDataSet(string datasetPath)
    {
        string[] lines = File.ReadAllLines(datasetPath);
        ImageData[] data = new ImageData[Lines.GetUpperBound(0)];
    
        for (int i = 0; i <= lines.GetUpperBound(0); i++)
        {
            string[] stringSplit = lines[i].Split('|');
            int number = Convert.ToInt32(stringSplit[1]);
            int[] flat = FlattenArray(ImagetoArray(StringSplit[0]));
            data[i] = new ImageData(flat, number);
        }
    
        return data;
    }
