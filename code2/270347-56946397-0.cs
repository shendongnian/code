     try
            {
                    var response = restClient.Execute<List<EmpModel>>(restRequest);
                    var jsonContent = response.Content;
                    var data = JsonConvert.DeserializeObject<List<EmpModel>>(jsonContent);
                    foreach (EmpModel item in data)
                    {
                        listPassingData?.Add(item);
                    }
                               }
            catch (Exception ex)
            {
                Console.WriteLine($"Data get mathod problem {ex} ");
            }
