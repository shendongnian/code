    public static string ToXmlFragment(this object input, string element)
    {
        //extension method, place in a static class somewhere
        return string.IsNullOrEmpty(input.ToString()) ? 
            string.Format("<{0}></{0}>",element) :
            string.Format("<{0}>{1}</{0}>",element,input);
    }
    reasonFrag.InnerXml = reason.ToXmlFragment("ReasonForPayment");
