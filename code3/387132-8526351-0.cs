    class XAVWSClient
    {
        static void Main()
        {
            try
            {
            XAVService xavSvc = new XAVService();
            XAVRequest xavRequest = new XAVRequest();
            UPSSecurity upss = new UPSSecurity();
    UPSSecurityServiceAccessToken upssSvcAccessToken = new UPSSecurityServiceAccessToken();
            upssSvcAccessToken.AccessLicenseNumber = ;
            upss.ServiceAccessToken = upssSvcAccessToken;
            UPSSecurityUsernameToken upssUsrNameToken = new UPSSecurityUsernameToken();
            upssUsrNameToken.Username = ;
            upssUsrNameToken.Password = ;
            upss.UsernameToken = upssUsrNameToken;
            xavSvc.UPSSecurityValue = upss;
            RequestType request = new RequestType();
            //Below code contains dummy data for reference. Please update as required.
            String[] requestOption = { "1" };
            request.RequestOption = requestOption;
            xavRequest.Request = request;
            AddressKeyFormatType addressKeyFormat = new AddressKeyFormatType();
            String[] addressLine = { "3930 KRISTI COURT" };
            addressKeyFormat.AddressLine = addressLine;
            addressKeyFormat.PoliticalDivision2 = "SACRAMENTO";
            addressKeyFormat.PoliticalDivision1 = "CA";
            addressKeyFormat.PostcodePrimaryLow = "95827";
            addressKeyFormat.ConsigneeName = "Some Consignee";
            addressKeyFormat.CountryCode = "US";
            xavRequest.AddressKeyFormat = addressKeyFormat;
      System.Net.ServicePointManager.CertificatePolicy = new    TrustAllCertificatePolicy();
          
            //serialize object (Debugging)
      System.Xml.Serialization.XmlSerializer x = new     System.Xml.Serialization.XmlSerializer(xavRequest.GetType());
            Stream stream = File.Open("SerializedXAVRequest.xml", FileMode.Create);
            x.Serialize(stream, xavRequest);
            XAVResponse xavResponse = xavSvc.ProcessXAV(xavRequest);
     Console.WriteLine("Response Status Code " +  xavResponse.Response.ResponseStatus.Code);
     Console.WriteLine("Response Status Description " + xavResponse.Response.ResponseStatus.Description);
            Console.ReadLine();
