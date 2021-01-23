    int pagesViewed = (int)Session["PagesViewed"];
    if (pagesViewed == 2)
    {
        pagesViewed = 0;
    }
    else
    {
        pagesViewed++;
    }
    Session["PagesViewed"] = pagesViewed;
