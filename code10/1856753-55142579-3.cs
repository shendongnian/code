      public static void Main(string[] args)
    {
    	var path = @"c:\temp\fileName2.zip";
    	byte[] zipBytes = Convert.FromBase64String("UEsDBBQAAAAIAC5YR063vtp6EwEAALcBAAAJAAAAcHJpbWUudHh0ZZDfSsMwFMbvA3mHPoBCkv5Ze5EL1zkVnBPX2QsRmdtxLWuTkmSyvb0nUaogBHLO73x8+U6eRbIcXKuVLbX6BONgJzkl9c36bvaGvcWRFJSsnAFrK7AOjBesLTyatgcFTjJKFq2qtHFHA/N5JbnIEW1OfxETCSU/YAG9zMeuQhsZB48pqG3j5YIl3xYjyXmBMUJ7bYw2ZQPbg386oKuuK3U/dHDyYZeqOwecZpN81JQaV/DZQ3d7HnDbxsBm9wtrbQ64s+QX6IKeAY4GIShPKbmHDyfjPMv8DoMUeD+1+8bJNGZYT7VzupcFQ2nNJYtYxBMhorgosLzk48GxwLHnQTD5L6DkJfzzA7hXSmbwftz7PF9QSwECFAAUAAAACAAuWEdOt77aehMBAAC3AQAACQAAAAAAAAABACAAAAAAAAAAcHJpbWUudHh0UEsFBgAAAAABAAEANwAAADoBAAAAAA==");
    	using (FileStream fs = new FileStream(path, FileMode.Create))
    	{
    		fs.Write(zipBytes,0,zipBytes.Length);
    	}
    }
