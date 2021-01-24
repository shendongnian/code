    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public class FtpFileInfo
    	{
    		public string FileName;
    		public DateTime FileDate;
    		public long FileSize;
    		public object FileType;
    	}
    
    	public static void Main()
    	{
    		var xmlFileNames = fillClasses();
    		var newXmlFileNames = new List<FtpFileInfo>();
    		var res = xmlFileNames.Select(s => new
    		{
    			Country = s.FileName.Split('_')[1], 
    			Version = s.FileName.Split('_')[2],
    			ftpFileInfo = s
    		}).GroupBy(x => x.Country).Select(c=> new {
    			country = c.Key,
    			ftpFileInfo = c.OrderByDescending(t=> t.Version).First().ftpFileInfo
    		}).ToList();
    		
    		foreach(var item in res.OrderBy(c=> c.country))
    		{
    			var ftpFileInfo = new FtpFileInfo();
    			ftpFileInfo.FileName = item.ftpFileInfo.FileName;
    			ftpFileInfo.FileDate = item.ftpFileInfo.FileDate;
    			ftpFileInfo.FileSize = item.ftpFileInfo.FileSize;
    			ftpFileInfo.FileType = item.ftpFileInfo.FileType;
    			
    			newXmlFileNames.Add(ftpFileInfo);
    		}
    		
    		foreach(var newXmlFileName in newXmlFileNames)
    		{
    			Console.WriteLine(string.Format("FileName: {0} FileDate:  {1}  FileSize: {2}", newXmlFileName.FileName, newXmlFileName.FileDate, newXmlFileName.FileSize));
    		}
    		
    		
    	}
    
    	public static List<FtpFileInfo> fillClasses()
    	{
    		var ftpFileInfoList = new List<FtpFileInfo>();
    		var fileNames = new List<string>()
    		{"XXX_AE_V1_20160812132126.xml", "XXX_AE_V2_20160912142126.xml", "XXX_AE_V3_20161012152126.xml", "XXX_AU_V1_20190213142439.xml", "XXX_AU_V2_20190313142439.xml", "XXX_AU_V3_20190413142439.xml", "XXX_AU_V4_20190513142439.xml", "XXX_BR_V1_20170828214049.xml", "XXX_BR_V2_20170928214049.xml", "XXX_BR_V3_20171028214049.xml", "XXX_BR_V4_20171038214049.xml", "XXX_BR_V6_20171048214049.xml"};
    		foreach (var fileName in fileNames)
    		{
    			ftpFileInfoList.Add(new FtpFileInfo()
    			{FileName = fileName, FileDate = DateTime.Now, FileSize = 11111, FileType = null});
    		}
    
    		return ftpFileInfoList;
    	}
    }
