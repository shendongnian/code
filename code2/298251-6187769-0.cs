    [DataContract]
    public class SendMessageResponse
    {
        [DataMember]
        public bool Successful { get; set; }
        [DataMember]
        public List<string> Messages { get; set; }
        public SendMessageResponse()
        {
            this.Successful = true;
            this.Messages = new List<string>();
        }
        public void ProcessException( Exception ex )
        {
            this.Messages.Add( ex.Message );
            this.Successful = false;
        }
    }
