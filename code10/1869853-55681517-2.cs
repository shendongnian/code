private static Schema.W[] Map(string[] headers, IEnumerable<string[]> data)
{
    Schema.W[] mapping = headers
        .Select((x, index) => new Schema.W
        {
            property_0 = x,   
            property_1 = data
                .Select((z) => new Schema.WEntry
                {
                    child_0 = z[0],
                    child_1 = z[index + 1]
                }).ToArray()
        }).ToArray();
    return mapping;
}
Old code starts here:
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
