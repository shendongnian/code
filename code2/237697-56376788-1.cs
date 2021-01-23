    /// <summary>
    /// Sets the Browsable attribute value of a property of a non premitive type.
    /// NOTE: The class property must be decorated with [Browsable(...)] attribute.
    /// </summary>
    /// <param name="obj">An instance of the type that contains the property, of which the Browsable attribute value needs to be changed.</param>
    /// <param name="propertyName">Name of the type property, of which the Browsable attribute value needs to be changed</param>
    /// <param name="isBrowsable">Browsable Value</param>
    public static void SetBrowsableAttributeOfAProperty<T>(T obj, string propertyName, bool isBrowsable)
    {
        if (typeof(T).GetInterface("IEnumerable") != null && typeof(T) != typeof(string))   //String type needs to be filtered out as String also implements IEnumerable<char> but its not a normal collection rather a primitive type
        {
            //Get the element type of the IEnumerable collection
            Type objType = obj.GetType().GetGenericArguments()?.FirstOrDefault();       //when T is a collection that implements IEnumerable except Array
            if (objType == null) objType = obj.GetType().GetElementType();              //when T is an Array
    
            SetBrowsableAttributeOfAProperty(objType, propertyName, isBrowsable);
        }
        else
            SetBrowsableAttributeOfAProperty(typeof(T), propertyName, isBrowsable);
