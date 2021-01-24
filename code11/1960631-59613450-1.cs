public class ParameterValueChangedSoapExtension : SoapExtension
{
	private Stream streamChainedAfterUs = null;
	private Stream streamChainedBeforeUs = null;
	private const int STREAMBUFFERSIZE = 65535;
	private ParameterValueChangedSoapExtensionAttribute ParameterValueChangedSoapExtensionAttribute = null;
	public override Stream ChainStream(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		Stream ret = null;
		this.streamChainedBeforeUs = stream;
		this.streamChainedAfterUs = new MemoryStream();
		ret = this.streamChainedAfterUs;
		return ret;
	}
	public override object GetInitializer(Type serviceType)
	{
		throw new NotSupportedException();
	}
	public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
	{
		if (attribute == null)
		{
			throw new ArgumentNullException("attribute");
		}
		object ret = attribute;
		return ret;
	}
	public override void Initialize(object initializer)
	{
		if (initializer == null)
		{
			throw new ArgumentNullException("initializer");
		}
		ParameterValueChangedSoapExtensionAttribute = initializer as ParameterValueChangedSoapExtensionAttribute;
		if (ParameterValueChangedSoapExtensionAttribute == null)
		{
			throw new InvalidOperationException(String.Format("initializer must be of type {0}, but its a {1}!", typeof(ParameterValueChangedSoapExtensionAttribute), initializer.GetType()));
		}
	}
	public override void ProcessMessage(SoapMessage message)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
		switch(message.Stage)
		{
			case SoapMessageStage.BeforeSerialize:
				break;
			case SoapMessageStage.AfterSerialize:
				streamChainedAfterUs.Position = 0;
				Copy(streamChainedAfterUs, streamChainedBeforeUs);
				break;
			case SoapMessageStage.BeforeDeserialize:
				UpdateMessage(message);
				streamChainedAfterUs.Position = 0;
				break;
			case SoapMessageStage.AfterDeserialize:
				break;
			default:
				throw new NotImplementedException(message.Stage.ToString());
		}
	}
	private void UpdateMessage(SoapMessage message)
	{
		var soapMsgAsString = ReadOriginalSoapMessage();
		var soapMsgRootNode = XElement.Parse(soapMsgAsString);
		var callDescriptorNode = FindCallDescriptorNode(soapMsgRootNode, message.MethodInfo.Name);
		var ns = callDescriptorNode.Name.Namespace;
		var originalNameWeLookFor = ns + ParameterValueChangedSoapExtensionAttribute.OriginalParameterName;
		var nodeWithOriginalName = callDescriptorNode.Elements().FirstOrDefault(i => i.Name == originalNameWeLookFor);
		if (nodeWithOriginalName != null)
		{
			//Here implement according to your need!
			nodeWithOriginalName.Value = nodeWithOriginalName.split(' ')[0];
			var nodeWithCurrentName = new XElement(ns + ParameterValueChangedSoapExtensionAttribute.CurrentParameterName, nodeWithOriginalName.Value);
			nodeWithOriginalName.AddAfterSelf(nodeWithCurrentName);
			nodeWithOriginalName.Remove();
		}
		WriteResultSoapMessage(soapMsgRootNode.ToString());
	}
	private XElement FindCallDescriptorNode(XElement soapMsgRootNode, string methodName)
	{
		XElement ret = null;
		var soapBodyName = soapMsgRootNode.Name.Namespace + "Body";
		var soapBodyNode = soapMsgRootNode.Elements().First(i => i.Name == soapBodyName);
		ret = soapBodyNode.Elements().First(i => i.Name.LocalName == methodName);
		return ret;
	}
	private void WriteResultSoapMessage(string msg)
	{
		streamChainedAfterUs.Position = 0;
		using (var sw = new StreamWriter(streamChainedAfterUs, Encoding.UTF8, STREAMBUFFERSIZE, true))
		{
			sw.Write(msg);
		}
	}
	private string ReadOriginalSoapMessage()
	{
		string ret = null;
		using (var sr = new StreamReader(streamChainedBeforeUs, Encoding.UTF8, false, STREAMBUFFERSIZE, true))
		{
			ret = sr.ReadToEnd();
		}
		return ret;
	}
	private void Copy(Stream from, Stream to)
	{
		using (var sr = new StreamReader(from, Encoding.UTF8, false, STREAMBUFFERSIZE, true))
		{
			using (var sw = new StreamWriter(to, Encoding.UTF8, STREAMBUFFERSIZE, true))
			{
				var content = sr.ReadToEnd();
				sw.Write(content);
			}
		}
	}
}
[AttributeUsage(AttributeTargets.Method, AllowMultiple=true)]
public class ParameterValueChangedSoapExtensionAttribute : SoapExtensionAttribute
{
	public override Type ExtensionType
	{
		get { return typeof(ParameterNameChangedSoapExtension); }
	}
	public override int Priority { get; set; }
	public string CurrentParameterName { get; private set; }
	public string OriginalParameterName { get; private set; }
	public ParameterValueChangedSoapExtensionAttribute()
	{
		this.CurrentParameterName = "inp1";
		this.OriginalParameterName = "inp1";
	}
}
Please go through the below link for more information on the SOAP Extensions - 
[Soap Extensions][1]
[SoapExtensionAttribute][2]
  [1]: https://docs.microsoft.com/en-us/previous-versions/dotnet/netframework-4.0/s25h0swd(v=vs.100)?redirectedfrom=MSDN
  [2]: https://docs.microsoft.com/en-us/dotnet/api/system.web.services.protocols.soapextensionattribute?view=netframework-4.8
