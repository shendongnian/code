    static uint MultiplyNumbers(uint x, uint y)
    {
        System.Net.WebClient myClient = new System.Net.WebClient();
        string sData = myClient.DownloadString(string.Format("http://www.google.com/search?q={0}*{1}&btnG=Search",x,y));
        string ans = x.ToString() + " * " + y.ToString() + " = ";
        int iBegin = sData.IndexOf(ans,50) + ans.Length ;
        int iEnd = sData.IndexOf('<',iBegin);
        return Convert.ToUInt32(sData.Substring(iBegin, iEnd - iBegin).Trim());
    }
