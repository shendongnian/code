        public class Comparer
        {
            private object first, second;
    
            public Comparer(object first, object second)
            {
                this.first = first;
                this.second = second;
            }
    
            public List<string> Compare()
            {
                if (first.GetType() != second.GetType())
                {
                    return null;
                }
    
                BsonDocument firstDoc = first.ToBsonDocument();
                BsonDocument secondDoc = second.ToBsonDocument();
    
                return Compare(firstDoc, secondDoc);
            }
    
            private List<string> Compare(BsonDocument first, BsonDocument second)
            {
                List<string> changedFields = new List<string>();
    
                foreach (string elementName in first.Names)
                {
                    BsonElement element = first.GetElement(elementName);
    
                    if (element.Value.IsBsonDocument)
                    {
                        BsonDocument elementDocument = element.Value.AsBsonDocument;
    
                        BsonDocument secondElementDocument =
                            second.GetElement(element.Name).Value.AsBsonDocument;
    
                        if (elementDocument.ElementCount > 1 &&
                            secondElementDocument.ElementCount ==
                            elementDocument.ElementCount)
                        {
                            foreach (string value in (Compare(elementDocument,
                                                           secondElementDocument)))
                            {
                                changedFields.Add(value);
                            }
                        }
    
                        else
                        {
                            changedFields.Add(element.Name);
                        }
                    }
    
                    else if (element.Value != second.GetElement(element.Name).Value)
                        changedFields.Add(element.Name);
                }
    
                return changedFields;
            }
    }
