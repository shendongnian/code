    foreach (Admin.DTO.SiteMap t in sites)
        {
            flg = false;
            for each (Admin.DTO.SmallSites f in smallsites)
                if (t.Title == f.Title) flg = true;
            if (flg)
            {
                myString1.Append(" <input type='checkbox'  checked='yes' value='"     +           t.Title + "'/> ");
                myString1.Append(t.Title);
            }
            else {
    
                myString1.Append(" <input type='checkbox'  value='" + t.Title +        "'/> ");
                myString1.Append(t.Title);
            }
        }
