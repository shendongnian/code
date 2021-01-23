    public class TextToPutOperationHandler : HttpOperationHandler<HttpRequestMessage, string>
        {
            public TextToPutOperationHandler() 
                : this("theTextToPut")
            { }
    
            private TextToPutOperationHandler(string outputParameterName) 
                : base(outputParameterName)
            { }
    
            public override string OnHandle(HttpRequestMessage input)
            {
                return input.Content.ReadAsString();
            }
        }
