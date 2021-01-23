	using System;
	using System.IO;
	using System.Text.RegularExpressions;
	using System.Web.Services.Protocols;
	namespace mAdcOW.SoapCleanerModule
	{
		[AttributeUsage(AttributeTargets.Method)]
		public class SOAPCleaner : SoapExtensionAttribute
		{
			public override Type ExtensionType
			{
				get { return typeof (SOAPCleanerExtension); }
			}
			public override int Priority { get; set; }
		}
		public class SOAPCleanerExtension : SoapExtension
		{
			private static readonly Regex _reInvalidXmlChars = new Regex(@"&#x[01]?[0123456789ABCDEF];",
																		 RegexOptions.Compiled |
																		 RegexOptions.CultureInvariant);
			private Stream _originalStream;
			private MemoryStream _processStream;
			public override void Initialize(object initializer)
			{
			}
			public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
			{
				return null;
			}
			public override object GetInitializer(Type serviceType)
			{
				return null;
			}
			public override Stream ChainStream(Stream stream)
			{
				_originalStream = stream;
				_processStream = new MemoryStream();
				return _processStream;
			}
			public override void ProcessMessage(SoapMessage message)
			{
				switch (message.Stage)
				{
					case SoapMessageStage.BeforeSerialize:
						{
							break;
						}
					case SoapMessageStage.AfterSerialize:
						{
							// This is the message we send for our soap call
							// Just pass our stream unmodified
							_processStream.Position = 0;
							Copy(_processStream, _originalStream);
							break;
						}
					case SoapMessageStage.BeforeDeserialize:
						{
							// This is the message we get back from the webservice
							CopyAndClean(_originalStream, _processStream);
							//Copy(_originalStream, _processStream);
							_processStream.Position = 0;
							break;
						}
					case SoapMessageStage.AfterDeserialize:
						break;
					default:
						break;
				}
			}
			private void CopyAndClean(Stream from, Stream to)
			{
				TextReader reader = new StreamReader(from);
				TextWriter writer = new StreamWriter(to);
				string msg = reader.ReadToEnd();
				string cleanMsg = _reInvalidXmlChars.Replace(msg, "");
				writer.WriteLine(cleanMsg);
				writer.Flush();
			}
			private void Copy(Stream from, Stream to)
			{
				TextReader reader = new StreamReader(from);
				TextWriter writer = new StreamWriter(to);
				writer.WriteLine(reader.ReadToEnd());
				writer.Flush();
			}
		}
	}
