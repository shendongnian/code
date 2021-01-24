var yValues = new List<Schema.W[]>();
Schema.W[] y = null;
for (int i = 0; i < headers.Length; i++)
    {
        y = data
            .Select((z) => new Schema.W
                {
                    property_0 = z[0],
                    property_1 = decimal.Parse(z[i + 1])
                }).ToArray();
                    yValues.Add(y);
                }
    }
And then finally:
var finalList = new List<Schema.W>();
Schema.W = null;
for (int i = 0; i < headers.Length; i++)
    {
        mapping = new Schema.W
        {
            innerNodes = yValues[i]
        };
                finalList.Add(mapping);
    }
