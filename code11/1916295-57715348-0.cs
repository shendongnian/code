c#
XmlTextReader xmlreader = new XmlTextReader(new System.IO.StringReader(resp));
DataContractSerializer ser = new DataContractSerializer(typeof(DataTable));
DataTable datos = (DataTable)ser.ReadObject(xmlreader);
So in the end, I will keep my code like this:
c#
HttpWebRequest request = WebRequest.Create("urlservice.svc") as HttpWebRequest;
request.Method = "GET";
HttpWebResponse response = request.GetResponse() as HttpWebResponse;
StreamReader reader = new StreamReader(response.GetResponseStream());
string resp = reader.ReadToEnd();
XmlTextReader xmlreader = new XmlTextReader(new System.IO.StringReader(resp));
DataContractSerializer ser = new DataContractSerializer(typeof(DataTable));
DataTable data= (DataTable)ser.ReadObject(xmlreader);
