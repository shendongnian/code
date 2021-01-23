    using(var fs = new System.IO.FileStream(@"m:\delme.zip", 
                                            FileMode.Open,
                                            FileAccess.Write,
                                            FileShare.None))
    {
		var zeros = new byte[fs.Length];
		
		fs.Write(zeros, 0, zeros.Length);		
    }
