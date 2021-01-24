            public ViewViewComponentResult Invoke()
        {
            List<object> allmenulist = new List<object>();
            var client = httpClientFactory.CreateClient("inventorio");
            client.DefaultRequestHeaders.Add("Token", HttpContext.Request.Cookies["Token"]);
            var response = client.GetAsync(client.BaseAddress + "/title/gettitlesbycompanyid");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var d = result.Content.ReadAsAsync<dynamic>();
                d.Wait(); // I am getting the error this line
                allmenulist = d.Result.name as List<TitleViewModel>;
            }
            return View(allmenulist);
        }
