c#
    [HttpPost]
    public async Task<IActionResult> EditComment(MpComment comment)
    {
        comment.Id = 0;
        _repo.AddComment(comment);
        if (await _repo.SaveChangesAsync())
            return RedirectToAction("ViewComments");
        else
            return View(comment);
    }
to
> **HomeController.cs**
c#
    [HttpPost]
    public async Task<IActionResult> EditComment()
    {
        var form = Request.Form.ToList();
        var comment = new MpComment
        {
            Id          = 0,
            Mp_Post_Id  = Int32.Parse(form.Where(x => x.Key == "Mp_Post_Id").FirstOrDefault().Value),
            Mp_Guest_Id = Int32.Parse(form.Where(x => x.Key == "Mp_Guest_Id").FirstOrDefault().Value),
            Comment     = form.Where(x => x.Key == "Comment").FirstOrDefault().Value,
            Karma       = Int32.Parse(form.Where(x => x.Key == "Karma").FirstOrDefault().Value),
            Approved    = Int32.Parse(form.Where(x => x.Key == "Approved").FirstOrDefault().Value),
            Ip          = form.Where(x => x.Key == "Ip").FirstOrDefault().Value,
            Agent       = form.Where(x => x.Key == "Agent").FirstOrDefault().Value,
            Create      = Convert.ToDateTime(form.Where(x => x.Key == "Create").FirstOrDefault().Value),
            Update      = Convert.ToDateTime(form.Where(x => x.Key == "Update").FirstOrDefault().Value)
        };
        _repo.AddComment(comment);
        if (await _repo.SaveChangesAsync())
            return RedirectToAction("ViewComments");
        else
            return View(comment);
    }
...and everything works as expected. 
### Additional note
These values were easy enough to retrieve, in case anyone else has a similar issue. Simply convert the request form data into a `List` (as above) and print out those results via the output console.
**Example:**
c#
    [HttpPost]
    public methodExpectingPostback()
    {
        var form = Request.Form.ToList();
        foreach (var item in form)
        {
            Debug.WriteLine($"{item.Key} : {item.Value}");
        }
    }
