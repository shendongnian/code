      public class JsonContentTypeMapper : WebContentTypeMapper
        {
            public override WebContentFormat
                       GetMessageFormatForContentType(string contentType)
            {
                if (contentType == "text/javascript")
                {
                    return WebContentFormat.Raw;
                }
                else
                {
                    return WebContentFormat.Json;
                }
            }
        }
