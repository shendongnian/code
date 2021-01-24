string url = "http://tsetmc.com/tsev2/data/Export-txt.aspx?t=i&a=1&b=0&i=43283802997035462";
string path = "111.csv";
using (FileStream fileStream = new FileStream(path, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
{
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = WebRequestMethods.Http.Get;
    request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                
    const int BUFFER_SIZE = 16 * 1024;
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
        using (var responseStream = response.GetResponseStream())
        {
            var buffer = new byte[BUFFER_SIZE];
            int bytesRead;
            do
            {
                bytesRead = responseStream.Read(buffer, 0, BUFFER_SIZE);
                fileStream.Write(buffer, 0, bytesRead);
            } while (bytesRead > 0);
        }
    }
}
