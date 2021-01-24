            static void Main(string[] args)
            {
                
                string url_with_sasToken = "https://xxx.table.core.windows.net/ttt?sasToken";
    
                MyClass entity = new MyClass
                {
                    PartitionKey = "ivan2",
                    RowKey = "y1",
                    Name = "jack60",
                    TestId = Guid.NewGuid()
                };
                
    
                //here, I add the odata type for Guid type
                string s = JsonConvert.SerializeObject(entity).Replace("}","");
                s += ",\"TestId@odata.type\"" + ":" + "\"Edm.Guid\"}";
                Console.WriteLine(s);
    
                var content = new StringContent(s, Encoding.UTF8, "application/json");
    
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new
              MediaTypeWithQualityHeaderValue("application/json"));
                    var t2 = client.PostAsync(url_with_sasToken , content).GetAwaiter().GetResult();
                    Console.WriteLine(t2.StatusCode);
                }
    
                Console.WriteLine("completed---");
                Console.ReadLine();
            }
