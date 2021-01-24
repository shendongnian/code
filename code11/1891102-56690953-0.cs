    using System;
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using System.Xml;
    
    namespace EstesWebService {
        public class EstesTrackingMessageInspector : IClientMessageInspector {
            public void AfterReceiveReply(ref Message reply, object correlationState) {
                var doc = new XmlDocument();
                var ms = new MemoryStream(); 
                var writer = XmlWriter.Create(ms);
                reply.WriteMessage(writer);
                writer.Flush();
                ms.Position = 0;
                doc.Load(ms);
    
                //fix the XML
                addNil(doc.SelectNodes(".//shipments"));
                foreach (XmlNode node in doc.SelectNodes(".//eventTimeStamp"))
                    fixDateTimeFormat(node);
    
                ms.SetLength(0);
                writer = XmlWriter.Create(ms);
                doc.WriteTo(writer);
                writer.Flush();
                ms.Position = 0;
                var reader = XmlReader.Create(ms);
                reply = Message.CreateMessage(reader, int.MaxValue, reply.Version);
            }
    
            public object BeforeSendRequest(ref Message request, IClientChannel channel) {
                return null;
            }
    
            private void addNil(XmlNodeList nodes) {
                foreach (XmlNode node in nodes) {
                    if (node.HasChildNodes)
                        addNil(node.ChildNodes);
                    else if (string.IsNullOrWhiteSpace(node.InnerText) && node.Attributes != null && node.Attributes.GetNamedItem("xsi:nil") == null) {
                        var attr = node.OwnerDocument.CreateAttribute("xsi", "nil", "http://www.w3.org/2001/XMLSchema-instance");
                        attr.Value = "true";
                        node.Attributes.SetNamedItem(attr);
                    }
                }
            }
    
            private void fixDateTimeFormat(XmlNode node) {
                if (node != null && !string.IsNullOrWhiteSpace(node.InnerText)) {
                    DateTimeOffset dt;
                    if (DateTimeOffset.TryParse(node.InnerText.Trim(), out dt))
                        node.InnerText = dt.ToString("O");
                }
            }
    
        }
    
        public class EstesTrackingEndpointBehavior : IEndpointBehavior {
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) {
            }
    
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) {
                clientRuntime.MessageInspectors.Add(new EstesTrackingMessageInspector());
            }
    
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) {
            }
    
            public void Validate(ServiceEndpoint endpoint) {
            }
        }
    }
