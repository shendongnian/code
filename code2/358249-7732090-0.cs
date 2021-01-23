    [HttpPost]        
        public ActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                RestClient restClient = new RestClient("http://localhost:4778");
                RestRequest request = new RestRequest("games/daniel",Method.POST);
                request.AddBody(game);
                RestResponse response = restClient.Execute(request);
                if (response.StatusCode != System.Net.HttpStatusCode.InternalServerError)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(game);
