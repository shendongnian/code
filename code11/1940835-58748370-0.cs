    XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
    using (var reader = new StreamReader(xmlFilePath))
    {
         var envelope = ((Envelope)serializer.Deserialize(reader));
         var csv_content = new List<string>();
         var headers = new[] { "CentreName", "Country", "CustomerId", "DOB", "Email", "ExpiryDate" };
         csv_content.Add(string.Join(",", headers));
         foreach (var data in envelope.Body
                                  .GetMarketingAllCardholderDataResponse
                                      .GetMarketingAllCardholderDataResult
                                          .MarketingAllCardholder
                                              .MarketingAllCardholderData)
         {
            var row_data = new[] 
            { 
                data.CentreName, 
                data.Country, 
                data.CustomerId, 
                data.DOB, 
                data.Email, 
                data.ExpiryDate 
            };
            csv_content.Add(string.Join(",", row_data));
         }
         File.WriteAllLines("csvFilePath.csv", csv_content);
    }
