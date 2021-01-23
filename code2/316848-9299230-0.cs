    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Web;
    using System.ServiceModel.Configuration;
    using System.ServiceModel.Dispatcher;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public class JsonNetBehaviorExtension : BehaviorExtensionElement
    {
        public class JsonNetBehavior : WebHttpBehavior
        {
            internal class MessageFormatter : IDispatchMessageFormatter
            {
                JsonSerializer serializer = null;
                internal MessageFormatter()
                {
                    serializer = new JsonSerializer();
                }
                public void DeserializeRequest(Message message, object[] parameters)
                {
                    throw new NotImplementedException();
                }
                public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
                {
                    var stream = new MemoryStream();
                    var streamWriter = new StreamWriter(stream, Encoding.UTF8);
                    var jtw = new JsonTextWriter(streamWriter);
                    serializer.Serialize(jtw, result);
                    jtw.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    return WebOperationContext.Current.CreateStreamResponse(stream, "application/json");
                }
            }
            protected override IDispatchMessageFormatter GetReplyDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
            {
                return new MessageFormatter();
            }
        }
        public JsonNetBehaviorExtension() { }
        public override Type BehaviorType
        {
            get
            {
                return typeof(JsonNetBehavior);
            }
        }
        protected override object CreateBehavior()
        {
            var behavior = new JsonNetBehavior();
            behavior.DefaultBodyStyle = WebMessageBodyStyle.WrappedRequest;
            behavior.DefaultOutgoingResponseFormat = WebMessageFormat.Json;
            behavior.AutomaticFormatSelectionEnabled = false;
            return behavior;
        }
    }
