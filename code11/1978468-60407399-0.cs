    string stringJson = @"{
                                  'Property1':[
                                    {'type':'header','version':'4.8.3','comment':'Export to JSON plugin for PHPMyAdmin'},
                                   {'type':'database','name':'archaism_dictionary'},
                                   {'type':'table','name':'dictionary','database':'archaism_dictionary','data':
                                   [
                                    {'id':'0','word':'wordOne','synonym':null,'definition':'defOne'},
                                     {'id':'1','word':'wortTwo','synonym':null,'definition':'defTwo'}
                                  ]
                                  }
                                 ]
                                }";
            try
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var list = JsonConvert.DeserializeObject<BaseResponse>(stringJson,settings);
                string result = list.Property1[2].data[0].word;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
