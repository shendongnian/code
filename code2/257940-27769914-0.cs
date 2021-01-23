	using HtmlAgilityPack;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.ServiceModel.Syndication;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	using System.Xml;
	namespace Search
	{
		public partial class Form1 : Form
		{
			// load snippet
			HtmlAgilityPack.HtmlDocument htmlSnippet = new HtmlAgilityPack.HtmlDocument();
			public Form1()
			{
				InitializeComponent();
			}
			private void btn1_Click(object sender, EventArgs e)
			{
				listBox1.Items.Clear();
				StringBuilder sb = new StringBuilder();
				byte[] ResultsBuffer = new byte[8192];
				string SearchResults = "http://google.com/search?q=" + txtKeyWords.Text.Trim();
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(SearchResults);
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream resStream = response.GetResponseStream();
				string tempString = null;
				int count = 0;
				do
				{
					count = resStream.Read(ResultsBuffer, 0, ResultsBuffer.Length);
					if (count != 0)
					{
						tempString = Encoding.ASCII.GetString(ResultsBuffer, 0, count);
						sb.Append(tempString);
					}
				}
				while (count > 0);
				string sbb = sb.ToString();
				HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
				html.OptionOutputAsXml = true;
				html.LoadHtml(sbb);
				HtmlNode doc = html.DocumentNode;
				
				foreach (HtmlNode link in doc.SelectNodes("//a[@href]"))
				{
					//HtmlAttribute att = link.Attributes["href"];
					string hrefValue = link.GetAttributeValue("href", string.Empty);
					if (!hrefValue.ToString().ToUpper().Contains("GOOGLE") && hrefValue.ToString().Contains("/url?q=") && hrefValue.ToString().ToUpper().Contains("HTTP://"))
					{
						int index = hrefValue.IndexOf("&");
						if (index > 0)
						{
							hrefValue = hrefValue.Substring(0, index);
							listBox1.Items.Add(hrefValue.Replace("/url?q=", ""));
						}
					}
				}
			}
		}
	}
