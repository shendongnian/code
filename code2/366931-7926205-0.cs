    string query;
    try {
        query = GenerateQueryString();
    }
    catch (Exception ex) {
        ModelState.AddModelError("error", ex.Message);
        return View();
    }
    
