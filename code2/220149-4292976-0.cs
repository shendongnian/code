    void BindElements<T, TProperty>(IEnumerable<T> dataObjects,
                                    Func<T, TProperty> selector)
    {
        Paragraph para = new Paragraph();
    
        foreach (T item in dataObjects)
        {
           // Notice: by delegating the only type-specific aspect of this method
           // (the property) to a Func<T, TProperty>, we are able to package MOST
           // of the code in a reusable form.
           var property = selector(item);
           InlineUIContainer uiContainer = this.CreateElementContainer(property)
           para.Inlines.Add(uiContainer);
        }
    
        FlowDocument flowDoc = new FlowDocument(para);
        this.Document = flowDoc;
    }
