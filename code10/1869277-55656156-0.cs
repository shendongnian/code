    public class XmlReplyRouter
    {
        private readonly IReplyTypeMapper _replyTypeMapper;
        private readonly IHandlerFactory _handlerFactory;
        
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(Reply));
        public XmlReplyRouter(
            IReplyTypeMapper replyTypeMapper,
            IHandlerFactory handlerFactory)
        {
            _replyTypeMapper = replyTypeMapper;
            _handlerFactory = handlerFactory;
        }
        public void RouteReply(string replyXml)
        {
            using (var reader = new StringReader(replyXml))
            {
                var reply = (Reply)_serializer.Deserialize(reader);
                var replyType = _replyTypeMapper.GetReplyType(reply.Name);
                var handler = _handlerFactory.GetHandler(replyType);
                handler.HandleReply(reply);
            }
        }
    }
    public class Reply
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Result { get; set; }
        [XmlAnyElement]
        public XmlNode InnerXml { get; set; }
        public string XmlContent => InnerXml?.OuterXml;
    }
