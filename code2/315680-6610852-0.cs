    IDictionary customHTMLAttributes = new Dictionary<string, object>();
    if(x == true) 
       // Notice here that i'm using == not =. 
       // This is because I'm testing the value of x, not setting the value of x.
       // You could also simplfy this with if(x).
    {
    customHTMLAttributes.Add("readonly","readonly");
    }
    @Html.TextBoxFor(model => model.Name, customHTMLAttributes)
