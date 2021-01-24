    PdfSignatureAppDictionary getPdfSignatureAppProperty()
    {
    	PdfSignatureAppDictionary appPropDic = (PdfSignatureAppDictionary)GetAsDict(PdfName.APP);
    	if (appPropDic == null)
    	{
    		appPropDic = new PdfSignatureAppDictionary();
    		Put(PdfName.APP, appPropDic);
    	}
    	return appPropDic;
    }
