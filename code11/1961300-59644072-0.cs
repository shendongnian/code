    [HttpPost]
    public async Task<EResponseBase<Food_Response_v1>> InsertOrUpdate(FoodModel model)
    {
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    var fileContent = new StreamContent(model.ImageFile.InputStream)
                    {
                        Headers =
                        {
                            ContentLength = model.ImageFile.ContentLength,
                            ContentType = new MediaTypeHeaderValue(model.ImageFile.ContentType),
                            ContentDisposition=new ContentDispositionHeaderValue("form-data")
                            {
                                Name = "ImageFile",
                                FileName = model.ImageFile.FileName
                            }
                        }
                    };
                    content.Add(fileContent);
                    content.Add(new StringContent(model.FoodName), "FoodName");
                    content.Add(new StringContent(model.UPCScan), "UPCScan");
                    content.Add(new StringContent(model.FactoryID.ToString()), "FactoryID");
                    content.Add(new StringContent(model.FoodClassificationID.ToString()), "FoodClassificationID");
                    content.Add(new StringContent(model.TypeProduct), "TypeProduct");
                    content.Add(new StringContent(model.Quantity.ToString()), "Quantity");
                    content.Add(new StringContent(model.MeasurementID.ToString()), "MeasurementID");
                    
                    client.BaseAddress = new Uri(_urlBase);
                    var response = client.PostAsync(_endPointInsertOrUpdate, content).Result;
                }
            }
         //other stuffs you want
    }
