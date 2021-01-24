    var productAttributes = new string[] {"Car", "Bike"}.Select((s, i) => new Attributes()
    {
        AttributeId = i + 1,
        AttributeName = s,
        AttributesValues = new AttributesValue[]
        {
            new AttributesValue{AttributeValueId = 1, AttributeValueName = s + "Attr1"},
            new AttributesValue{AttributeValueId = 2, AttributeValueName = s + "Attr2"},
        }
    });
    Console.WriteLine(GetUniqueName(productAttributes));
