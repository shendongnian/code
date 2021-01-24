     public IActionResult GetStaticFile()
     {
            var mentionsLegalesModel = new MentionsLegalesModel();
            var htmlString = System.IO.File.ReadAllLines("./resources/html/mentionslegales.html");
            mentionsLegalesModel.Content = string.Join("", htmlString);
            return View(mentionsLegalesModel);
      }
