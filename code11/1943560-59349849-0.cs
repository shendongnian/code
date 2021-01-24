    // GET: Links/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        New newss = db.News.Find(id);
        if (newss == null)
        {
            return HttpNotFound();
        }
        int urlid = newss.ID;
        if (Session["URLHistory"] != null)
        {
            List<int> HistoryURLs = (List<int>)Session["URLHistory"];
            if (HistoryURLs.Exists((element => element == urlid)))
            {
                int i = newss.ClickCount;
                newss.ClickCount = i + 0;
                db.SaveChanges();
            }
            else
            {
                HistoryURLs.Add(urlid);
                Session["URLHistory"] = HistoryURLs;
                int i = newss.ClickCount;
                newss.ClickCount = i + 1;
                db.SaveChanges();
            }
        }
        else
        {
            List<int> HistoryURLs = new List<int>();
            HistoryURLs.Add(urlid);
            Session["URLHistory"] = HistoryURLs;
            int i = newss.ClickCount;
            newss.ClickCount = i + 1;
            db.SaveChanges();
        }
        return View(newss);
    }
