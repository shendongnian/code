    public void ShapeClicked(object obj)
    {
        var measurable = obj as IMeasurable;
        if (measurable == null)
            throw new InvalidOperationException(string.Format("We can only work with measurable types, which {0} is not.", obj.GetType());
    
        var measure = measurable.GetMeasure();
    }
