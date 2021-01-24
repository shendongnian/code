    In your code this isn't done correctly.  Specifically, I believe an `else` is missing in the following location:
            // unnamed nodes which contain nested objects 
            if (sub.Value.First.Type == JTokenType.Object)
            {
                foreach (var innerNode in sub.Value.Children())
                {
                    documentProperties.UnionWith(ParseJObject((JObject)innerNode));
                }
            }
        // ELSE SHOULD BE HERE
            documentProperty = CreateDocumentProperty(sub.Value);
