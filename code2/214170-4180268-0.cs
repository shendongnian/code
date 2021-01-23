	//Product Advertising API, ItemLookup: http://docs.amazonwebservices.com/AWSECommerceService/2010-10-01/DG/ItemLookup.html
	
	SprightlySoftAWS.REST MyREST = new SprightlySoftAWS.REST();
	
	String RequestURL;
	RequestURL = "https://ecs.amazonaws.com/onca/xml?Service=AWSECommerceService&Operation=ItemLookup&Version=2010-10-01";
	RequestURL += "&AWSAccessKeyId=" + System.Uri.EscapeDataString(AWSAccessKeyId) + "&SignatureVersion=2&SignatureMethod=HmacSHA256&Timestamp=" + Uri.EscapeDataString(DateTime.UtcNow.ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z"));
	RequestURL += "&ItemId=9781904233657";
	RequestURL += "&IdType=ISBN";
	RequestURL += "&SearchIndex=Books";
	
	String RequestMethod;
	RequestMethod = "GET";
	
	String SignatureValue;
	SignatureValue = MyREST.GetSignatureVersion2Value(RequestURL, RequestMethod, "", AWSSecretAccessKey);
	
	RequestURL += "&Signature=" + System.Uri.EscapeDataString(SignatureValue);
	
	Boolean RetBool;
	RetBool = MyREST.MakeRequest(RequestURL, RequestMethod, null);
	
	System.Diagnostics.Debug.Print("");
	System.Diagnostics.Debug.Print(MyREST.LogData);
	System.Diagnostics.Debug.Print("");
	
	String ResponseMessage = "";
	
	if (RetBool == true)
	{
	    System.Xml.XmlDocument MyXmlDocument;
	    System.Xml.XmlNamespaceManager MyXmlNamespaceManager;
	    System.Xml.XmlNode MyXmlNode;
	    System.Xml.XmlNodeList MyXmlNodeList;
	
	    MyXmlDocument = new System.Xml.XmlDocument();
	    MyXmlDocument.LoadXml(MyREST.ResponseString);
	
	    MyXmlNamespaceManager = new System.Xml.XmlNamespaceManager(MyXmlDocument.NameTable);
	    MyXmlNamespaceManager.AddNamespace("amz", "http://webservices.amazon.com/AWSECommerceService/2010-10-01");
	
	    MyXmlNodeList = MyXmlDocument.SelectNodes("amz:ItemLookupResponse/amz:Items/amz:Item", MyXmlNamespaceManager);
	
	    if (MyXmlNodeList.Count == 0)
	    {
	        ResponseMessage = "No items found.";
	    }
	    else
	    {
	        foreach (System.Xml.XmlNode ItemXmlNode in MyXmlNodeList)
	        {
	            MyXmlNode = ItemXmlNode.SelectSingleNode("amz:ItemAttributes/amz:Title", MyXmlNamespaceManager);
	            ResponseMessage += "Title = " + MyXmlNode.InnerText;
	
	            ResponseMessage += Environment.NewLine;
	        }
	    }
	
	    MessageBox.Show(ResponseMessage);
	}
	else
	{
	    ResponseMessage = MyREST.ResponseStringFormatted;
	
	    MessageBox.Show(ResponseMessage);
	}
