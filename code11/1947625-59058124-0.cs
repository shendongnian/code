	XmlReader respXML;
	using (StringWriter respWriter = new StringWriter())
	{
		XmlSerializer respSerializer = new XmlSerializer(typeof(OTA.OTA_HotelResNotifRS));
		respSerializer.Serialize(respWriter, rs);           // rs is my response object
		string resp = respWriter.ToString().Remove(0, 41);  // just to remove <?xml version="1.0" encoding="utf-8" ?> on the top of produced string
		respXML = XmlReader.Create(new StringReader(resp)); // finally, XmlReader has my body element
	}
	Message rsMessage = Message.CreateMessage(message.Version, "ReceiveMessageResponse", respXML);
	return rsMessage;
