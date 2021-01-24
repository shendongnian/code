    [AllowAnonymous]
    public IActionResult Error() {
        if (TempData["Message"] != null) {
            ErrorViewModel errorMessage = (ErrorViewModel) TempData["Message"];
            log.Log(errorMessage);    
        }
        
        return View(new ErrorViewModel
        { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
