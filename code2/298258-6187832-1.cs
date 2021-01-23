	String urlSchema1= @"/selector/(<lang>\w\w)/.+\.aspx?FamiId=(<FamiId>\d+);
    Match mExprStatic = Regex.Match(urlSchema1, RegexOptions.IgnoreCase | RegexOptions.Singleline);
     if (mExprStatic.Success || !string.IsNullOrEmpty(mExprStatic.Value))
     {
        String language = mExprStatic.Groups["lang"].Value;
		String FamId = mExprStatic.Groups["FamId"].Value;
	 }
    String urlSchema2= @"/selector/(<lang>\w\w)/F/(<FamId>\d+)/.+\.html";
    Match mExprStatic = Regex.Match(urlSchema2, RegexOptions.IgnoreCase | RegexOptions.Singleline);
     if (mExprStatic.Success || !string.IsNullOrEmpty(mExprStatic.Value))
     {
        String language = mExprStatic.Groups["lang"].Value;
		String FamId = mExprStatic.Groups["FamId"].Value;
	 }
