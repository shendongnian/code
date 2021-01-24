      using (var client = new HttpClient())
                {
                    var apiUrl = _config["MicroService:Base"] + string.Format("/Exam/{0}", examId);
                    var response = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, apiUrl))
                        .Result;
                    if (!response.IsSuccessStatusCode)
                        return Task.FromCanceled<ExamDetails>(new CancellationToken(true));
                    var content = response.Content.ReadAsStringAsync().Result;
                    return Task.FromResult((DtoExamDetails)JsonConvert.DeserializeObject(content,
                        typeof(ExamDetails)));
                }
