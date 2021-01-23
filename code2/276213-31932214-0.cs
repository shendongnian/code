           public string exHashMd5(string data)
        {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(data));
                byte[] result = md5.Hash;
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    str.Append(result[i].ToString("X2"));
                }
     /// The implementation like so. (Below) 
    
                NumberFormatInfo format = new NumberFormatInfo();
                format.NumberGroupSeparator = " ";
                format.NumberGroupSizes = new[] { 8 };
                format.NumberDecimalDigits = 0;
                string rstr = str.ToString();
                rstr = Regex.Replace(rstr, "(?!^).{8}", " $0", RegexOptions.RightToLeft);
                return rstr.ToString();
     /// At the end you get yourself a nice 4 way split.
     /// Test it out. have a go with chucking it into a 
     /// MessageBox.Show(exHashMd5("yourstring"));
        }
