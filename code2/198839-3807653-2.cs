    public string GetURL()
    {
       long MerchantID = CommonHelper.GetLoggedInMerchant(); 
       string querystringpackageinfo = ApplicationData.URL_MERCHANT_COMPANY_PACKAGE + "?   MerchantCompanyPayment"; 
       return querystringpackageinfo;
    }
  
