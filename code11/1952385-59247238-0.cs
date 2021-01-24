    using System;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    namespace WriteCData
    {
	class Program
	{
		static void Main(string[] args)
		{
			// some output to write to
			XmlTextWriter xtw = new XmlTextWriter(@"c:\temp\CDataTest.xml", null);
			// start at 'songs' element
			xtw.WriteStartElement("songs");
			xtw.WriteCData("<div class='ThumbContainer'>Some text here</div>");
			xtw.WriteStartElement("songsTitle");
			xtw.WriteCData("sometexthtml here");
			xtw.WriteEndElement();		// end "songTitle"
			xtw.WriteEndElement();		// end "songs"
			xtw.Flush();			// clean up
			xtw.Close();
		}
	}
    }
