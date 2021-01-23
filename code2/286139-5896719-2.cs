    public Form1()
    {
    	InitializeComponent();
    	string hexstr = FileToHexStr(path_to_file);
    	pictureBox1.Image = ConvertToBmp(hexstr, 200, 196, true);
    }
    
    private string FileToHexStr(string filename)
    {
    	StringBuilder sb = new StringBuilder();
    	string[] f = File.ReadAllLines(filename);
    	foreach (string s in f) sb.Append(s.Trim().Replace(" ", ""));
    	return sb.ToString();
    }
    
    private byte[] StringToByteArray(string hex)
    {
    	return Enumerable.Range(0, hex.Length)
    					 .Where(x => x % 2 == 0)
    					 .Select(x => System.Convert.ToByte(hex.Substring(x, 2), 16))
    					 .ToArray();
    }
    
    private Bitmap ConvertToBmp(string hexstr, int width, int height, bool isGrayScaleString)
    {
    	/// If hexstr is a color bitmap I assume that a single pixel
    	/// must be 3 values long (one for R, one for G, one for B);
    	/// if not, then every hex value is a pixel
    	int bpp = isGrayScaleString ? 1 : 3;
    	byte[] hexarr = StringToByteArray(hexstr);
    	// Check if string is correct
    	if (hexarr.Length != (width * height * bpp)) return null;
    
    	Bitmap bmp = new Bitmap(width, height);
    	int index = 0;
    	for (int i = 0; i < hexarr.Length; i +=  bpp)
    	{
    		int luma = (int)(isGrayScaleString ?
    			hexarr[index] :
    			// Formula to convert from RGB to Grayscale
    			// <see>http://www.bobpowell.net/grayscale.htm</see>
    			0.3 * hexarr[i] + 0.59 * hexarr[i + 1] + 0.11 * hexarr[i + 2]);
    		Color c = Color.FromArgb(luma, luma, luma);
    		bmp.SetPixel(index % width, index / width, c);
    		index++;
    	}
    	return bmp;
    }
