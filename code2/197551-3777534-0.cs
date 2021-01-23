    public string Transform(XPathDocument myXPathDoc, XslCompiledTransform myXslTrans)
    {
        try
        {
            using (var stm = new MemoryStream())
            {
                 myXslTrans.Transform(myXPathDoc, null, stm);
                 stm.Position = 0;
                 using (var sr = new StreamReader(stm))
                 {
                     return sr.ReadToEnd();
                 }
            }
        }
        catch (Exception e)
        {
            //Log the Exception
        }
    }
