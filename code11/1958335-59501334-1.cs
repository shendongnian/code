    string json = "{    \"ErrorMessage\":\"Transaction has been authorized successfully\",    \"ControlId\":1000.00,    \"Authorizations\":[        {            \"RMATranUUID\":\"1c1a88f7-d6cf-4ae8-87d3-ba06e9d9fe36\",            \"Payments\":[                {                    \"PaymentNumber\":\"1\",                    \"TotalPaymentsNumber\":24,                    \"AmountDue\":1000.0,                    \"AmountPaid\":0.00                }            ],            \"Term\":24,            \"OTBReleaseAmount\":null        },        {            \"RMATranUUID\":\"b012ba9c-2dbd-4961-8959-ec0afbafbe13\",            \"OTBReleaseAmount\":null        }    ]}";
			
    var jsonReader = new JsonTextReader(new StringReader(json));
	jsonReader.FloatParseHandling = FloatParseHandling.Decimal;
	var jObject = JObject.Load(jsonReader);
	Console.WriteLine(jObject["ControlId"].Value<decimal>()); // 1000.00
	Console.WriteLine(jObject); // prints your actual json
