    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Text;
    using System.IO;
    using System.Threading;
    using System.Security.Cryptography;
    
    namespace NiceFileExplorer.Classes
    {
        public class DownloadFile
        {
            public static bool DownloadFileMethod(HttpContext httpContext, string filePath, long speed)
            {
                bool ret = true;
                try
                {
                    switch (httpContext.Request.HttpMethod.ToUpper())
                    { //support Get and head method
                        case "GET":
                        case "HEAD":
                            break;
                        default:
                            httpContext.Response.StatusCode = 501;
                            return false;
                    }
                    if (!File.Exists(filePath))
                    {
                        httpContext.Response.StatusCode = 404;
                        return false;
                    }
                    //#endregion
    
                    var fileInfo = new FileInfo(filePath);
    
                    long startBytes = 0;
                    int packSize = 1024 * 10; //read in block，every block 10K bytes
                    string fileName = Path.GetFileName(filePath);
                    FileStream myFile = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    BinaryReader br = new BinaryReader(myFile);
                    long fileLength = myFile.Length;
    
                    int sleep = (int)Math.Ceiling(1000.0 * packSize / speed);//the number of millisecond
                    string lastUpdateTiemStr = File.GetLastWriteTimeUtc(filePath).ToString("r");
                    string eTag = HttpUtility.UrlEncode(fileName, Encoding.UTF8) + lastUpdateTiemStr;
    
                    //validate whether the file is too large
                    if (myFile.Length > Int32.MaxValue)
                    {
                        httpContext.Response.StatusCode = 413;
                        return false;
                    }
    
                    if (httpContext.Request.Headers["If-Range"] != null)
                    {
    
                        if (httpContext.Request.Headers["If-Range"].Replace("\"", "") != eTag)
                        {
                            httpContext.Response.StatusCode = 412;
                            return false;
                        }
                    }
                    //#endregion
    
                    try
                    {
    
                        httpContext.Response.Clear();
                        httpContext.Response.Buffer = false;
                        httpContext.Response.AddHeader("Content-MD5", GetMD5Hash(fileInfo));
                        httpContext.Response.AddHeader("Accept-Ranges", "bytes");
                        httpContext.Response.AppendHeader("ETag", "\"" + eTag + "\"");
                        httpContext.Response.AppendHeader("Last-Modified", lastUpdateTiemStr);
                        httpContext.Response.ContentType = "application/octet-stream";
                        httpContext.Response.AddHeader("Content-Disposition", "attachment;filename=" +
    
                        HttpUtility.UrlEncode(fileName, Encoding.UTF8).Replace("+", "%20"));
                        httpContext.Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
                        httpContext.Response.AddHeader("Connection", "Keep-Alive");
                        httpContext.Response.ContentEncoding = Encoding.UTF8;
                        if (httpContext.Request.Headers["Range"] != null)
                        {
                            httpContext.Response.StatusCode = 206;
                            string[] range = httpContext.Request.Headers["Range"].Split(new char[] { '=', '-' });
                            startBytes = Convert.ToInt64(range[1]);
                            if (startBytes < 0 || startBytes >= fileLength)
                            {
                                return false;
                            }
                        }
                        if (startBytes > 0)
                        {
                            httpContext.Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                        }
                        //#endregion
    
                        //send data
                        br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                        int maxCount = (int)Math.Ceiling((fileLength - startBytes + 0.0) / packSize);//download in block
                        for (int i = 0; i < maxCount && httpContext.Response.IsClientConnected; i++)
                        {
                            httpContext.Response.BinaryWrite(br.ReadBytes(packSize));
                            httpContext.Response.Flush();
                            if (sleep > 1) Thread.Sleep(sleep);
                        }
                        //#endregion
                    }
                    catch
                    {
                        ret = false;
                    }
                    finally
                    {
                        br.Close();
                        myFile.Close();
                    }
                }
                catch
                {
                    ret = false;
                }
                return ret;
            }
    
            private static string GetMD5Hash(FileInfo file)
            {
                var stream = file.OpenRead();
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(stream);
                stream.Close();
    
                var sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
    
        }
    }
