@Html.DropDownList("cardProgram", null, "--Select--", new
                       {
                           @class = "form-control input-group-lg",
                           @onChange = "return "
                       })
using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59066/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ViewBag.country = "";
                HttpResponseMessage response = await client.GetAsync("api/CardCreation/Configure");
                if (response.IsSuccessStatusCode)
                {
                    List<SelectListItem> cardPrograms = response.Content.ReadAsAsync<List<SelectListItem>>().Result;
                    ViewBag.cardProgram = cardPrograms;
                    return View();
                }
                else
                {
                    return View();
                }
}
