	using System;
	using System.Net;
	using System.Text;
	using System.Text.RegularExpressions;
	namespace DreamInCode.Snippets
	{
		public class IpFinder
		{
			public static IPAddress GetExternalIp()
			{
				string whatIsMyIp = "http://whatismyip.com";
				string getIpRegex = @"(?<=<TITLE>.*)\d*\.\d*\.\d*\.\d*(?=</TITLE>)";
				WebClient wc = new WebClient();
				UTF8Encoding utf8 = new UTF8Encoding();
				string requestHtml = "";
				try
				{
					requestHtml = utf8.GetString(wc.DownloadData(whatIsMyIp));
				}
				catch (WebException we)
				{
					// do something with exception
					Console.Write(we.ToString());
				}
				Regex r = new Regex(getIpRegex);
				Match m = r.Match(requestHtml);
				IPAddress externalIp = null;
				if (m.Success)
				{
					externalIp = IPAddress.Parse(m.Value);
				}
				return externalIp;
			}
		}
	}
