    namespace ConsoleAppForTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = "{" +
                              "\"@odata_context\": \"https://graph.microsoft.com/v1.0/$metadata#users\"," +
                              "\"@odata_nextLink\": \"https://graph.microsoft.com/v1.0/users?$top=999&$skiptoken=\"," +
                              "\"value\": [{" +
                                 "\"businessPhones\": [999999]," +
                                 "\"displayName\": \"___XXXXX_Conv_SA___\"," +
                                 "\"givenName\": null," +
                                 "\"jobTitle\": null," +
                                 "\"mail\": null," +
                                 "\"mobilePhone\": null," +
                                 "\"officeLocation\": null," +
                                 "\"preferredLanguage\": null," +
                                 "\"surname\": null," +
                                 "\"userPrincipalName\": \"__XXXXX_Conv_SA___@company.onmicrosoft.com\"," +
                                 "\"id\": \"e7dc80e8-482d-4020-bb81-eee9458f5a37\"" +
                              "}]" +
                          "}";
                jsonModel data = JsonConvert.DeserializeObject<jsonModel>(json);
                foreach (valueModel i in data.value.ToList())
                {
                    Console.WriteLine("Complete Value object");
                    Console.WriteLine("--------START---------");
                    Console.WriteLine(JsonConvert.SerializeObject(i));
                    Console.WriteLine("---------END----------");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("get value by property name");
                    Console.WriteLine("=> businessPhones:" + i.businessPhones[0]);
                    Console.WriteLine("=> displayName:" + i.displayName);
                    Console.WriteLine("=> givenName:" + i.givenName);
                    Console.WriteLine("=> jobTitle:" + i.jobTitle);
                    Console.WriteLine("=> mail:" + i.mail);
                    Console.WriteLine("=> and so on");
                }
                Console.ReadLine();
            }
            public class jsonModel
            {
                public string @odata_context { get; set; }
                public string @odata_nextLink { get; set; }
                public List<valueModel> value { get; set; }
            }
            public class valueModel
            {
                public List<string> businessPhones { get; set; }
                public string displayName { get; set; }
                public string givenName { get; set; }
                public string jobTitle { get; set; }
                public string mail { get; set; }
                public string mobilePhone { get; set; }
                public string officeLocation { get; set; }
                public string preferredLanguage { get; set; }
                public string surname { get; set; }
                public string userPrincipalName { get; set; }
                public string id { get; set; }
            }
        }
    }
