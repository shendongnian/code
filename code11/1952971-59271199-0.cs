    using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("<any url>");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var result = await client.PostAsync("projectVersions",
                        new StringContent(JsonConvert.SerializeObject(appVersionModel, Encoding.UTF8, "application/json");
                    
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Home/Index");
                    }
                    else if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        ModelState.AddModelError(string.Empty, "Authentication Error. Please contact administrator.");
                        return View(appVersionModel);
                    }
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                }
                catch (HttpException ex)
                {
                    ModelState.AddModelError(string.Empty, "Exception Occured in Http Request.");
                }
            }
