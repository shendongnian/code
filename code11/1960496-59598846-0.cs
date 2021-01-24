    [XmlRoot(ElementName="Header", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
	public class Header {
		[XmlElement(ElementName="Action", Namespace="http://www.w3.org/2005/08/addressing")]
		public string Action { get; set; }
		[XmlElement(ElementName="MessageID", Namespace="http://www.w3.org/2005/08/addressing")]
		public string MessageID { get; set; }
	}
	[XmlRoot(ElementName="result", Namespace="http://xmlns.oracle.com/apps/hcm/processFlows/core/flowActionsService/types/")]
	public class Result {
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }
		[XmlText]
		public string Text { get; set; }
	}
	[XmlRoot(ElementName="getFlowTaskInstanceStatusResponse", Namespace="http://xmlns.oracle.com/apps/hcm/processFlows/core/flowActionsService/types/")]
	public class GetFlowTaskInstanceStatusResponse {
		[XmlElement(ElementName="result", Namespace="http://xmlns.oracle.com/apps/hcm/processFlows/core/flowActionsService/types/")]
		public Result Result { get; set; }
		[XmlAttribute(AttributeName="ns0", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Ns0 { get; set; }
	}
	[XmlRoot(ElementName="Body", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
	public class Body {
		[XmlElement(ElementName="getFlowTaskInstanceStatusResponse", Namespace="http://xmlns.oracle.com/apps/hcm/processFlows/core/flowActionsService/types/")]
		public GetFlowTaskInstanceStatusResponse GetFlowTaskInstanceStatusResponse { get; set; }
	}
	[XmlRoot(ElementName="Envelope", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
	public class Envelope {
		[XmlElement(ElementName="Header", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
		public Header Header { get; set; }
		[XmlElement(ElementName="Body", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
		public Body Body { get; set; }
		[XmlAttribute(AttributeName="env", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Env { get; set; }
		[XmlAttribute(AttributeName="wsa", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Wsa { get; set; }
	}
