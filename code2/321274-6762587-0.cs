        string element = "element";
        string str = String.Empty;
        int elementsCount = 20;
        IDictionary<string,object> obj = new ExpandoObject();
        for (int i = 0; i < elementsCount; i++)
        {
            obj[element + i] = "value " + i;
        }
        dynamic viaDynamic = obj;
        string val0 = viaDynamic.element0; // = "value 0"
