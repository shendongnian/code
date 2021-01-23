    HtmlElementCollection inputColl = HTMLDoc.GetElementsByTagName("input");     
    foreach (HtmlElement inputTag in inputColl)     
    {         
        string valueAttribute = inputTag.GetAttribute("value");         
        if (valueAttribute.ToLower() == "sign up")        
        { 
            obj = inputTag.DomElement;                            
            mi = obj.GetType().GetMethod("click");                             
            mi.Invoke(obj, new object[0]);         
        }     
    } 
 
