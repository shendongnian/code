    private int DavLockBase_InternalProcessDavRequest(object sender, EventArgs e)
		{
			int _responseCode = (int)DavLockResponseCode.Ok;
			//string[] _lockTokens = this.RequestLock.GetLockTokens();
			//#1 the above line is incorrect. replaced with the following:
			string[] _lockTokens = this.ResponseLock.GetLockTokens();
			//Check to see if a lock refresh was requested
			if (base.HttpApplication.Request.Headers["If"] != null)
			{
				if (_lockTokens.Length == 1)
				{
					//#2 not sure why this should be done (or not), however I've seen this in other people corrections.
					//DavRefreshEventArgs _refreshEventArgs = new DavRefreshEventArgs(_lockTokens[0], this.RequestLock.LockTimeout);
					//OnRefreshLockDavRequest(_refreshEventArgs);
				}
				base.HttpApplication.Response.AppendHeader("Timeout", "Second-" + this.ResponseLock.LockTimeout);
			}
			else
			{
				//New lock request
				StringBuilder _opaquelockTokens = new StringBuilder();
				//#3 finally, added the check below, as most of the times, when using word 2010 there are no lock requests
				if (_lockTokens.Length > 0)
				{
					foreach (string _lockToken in _lockTokens)
						_opaquelockTokens.Append("<opaquelocktoken:" + _lockToken + ">");
					base.HttpApplication.Response.AppendHeader("Lock-Token", _opaquelockTokens.ToString());
				}
			}
			//Check to see if there were any process errors...
			Enum[] _errorResources = this.ProcessErrorResources;
			if (_errorResources.Length > 0)
			{
				//Append a response node
				XmlDocument _xmlDocument = new XmlDocument();
				XmlNode _responseNode = _xmlDocument.CreateNode(XmlNodeType.Element, _xmlDocument.GetPrefixOfNamespace("DAV:"), "response", "DAV:");
				//Add the HREF
				XmlElement _requestLockHrefElement = _xmlDocument.CreateElement("href", "DAV:");
				_requestLockHrefElement.InnerText = base.RelativeRequestPath;
				_responseNode.AppendChild(_requestLockHrefElement);
				//Add the propstat
				XmlElement _propstatElement = _xmlDocument.CreateElement("propstat", "DAV:");
				XmlElement _propElement = _xmlDocument.CreateElement("prop", "DAV:");
				XmlElement _lockDiscoveryElement = _xmlDocument.CreateElement("lockdiscovery", "DAV:");
				_propElement.AppendChild(_lockDiscoveryElement);
				_propstatElement.AppendChild(_propElement);
				XmlElement _statusElement = _xmlDocument.CreateElement("status", "DAV:");
				_statusElement.InnerText = InternalFunctions.GetEnumHttpResponse(DavLockResponseCode.FailedDependency);
				_propstatElement.AppendChild(_statusElement);
				_responseNode.AppendChild(_propstatElement);
				base.SetResponseXml(InternalFunctions.ProcessErrorRequest(this.ProcessErrors, _responseNode));
				_responseCode = (int)ServerResponseCode.MultiStatus;
			}
			else
			{
				//No issues
				using (Stream _responseStream = new MemoryStream())
				{
					XmlTextWriter _xmlWriter = new XmlTextWriter(_responseStream, new UTF8Encoding(false));
					_xmlWriter.Formatting = Formatting.Indented;
					_xmlWriter.IndentChar = '\t';
					_xmlWriter.Indentation = 1;
					_xmlWriter.WriteStartDocument();
					//Open the prop element section
					_xmlWriter.WriteStartElement("D", "prop", "DAV:");
					_xmlWriter.WriteStartElement("lockdiscovery", "DAV:");
					this.ResponseLock.ActiveLock.WriteTo(_xmlWriter);
					_xmlWriter.WriteEndElement();
					_xmlWriter.WriteEndElement();
					_xmlWriter.WriteEndDocument();
					_xmlWriter.Flush();
					base.SetResponseXml(_responseStream);
					_xmlWriter.Close();
				}
			}
			return _responseCode;
		}
