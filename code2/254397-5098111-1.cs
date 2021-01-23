      using System.Xml;
      using System.Xml.XPath;
      using System.Xml.Linq;
      using System.Net;
      ...
      HttpWebRequest myReq = ( HttpWebRequest )WebRequest.Create( "http://www.contoso.com/" );
      myReq.AllowAutoRedirect = true;
      myReq.MaximumAutomaticRedirections = 5;
      XNode result;
      using( var responseStream = XmlReader.Create( myReq.GetResponse( ).GetResponseStream( ) ) ) {
        result = XElement.Load( responseStream );
      }
      var title = result.XPathSelectElement( "//title" ).Value;
