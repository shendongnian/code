        var category = wpe.Categories.First(c => c.id == catid);
        var city = wpe.Cities.First(c => c.id == cid);
        Post p = new Post
        {
            title = txtTitle.Text,
            description = txtDescription.Text,
            User = u,
            initialprice = 0,
            finalprice = 10,
            postdate = DateTime.Now,
            closedate = DateTime.Now.AddDays(Convert.ToInt32(cmbDays.SelectedValue)),
            currentprice = 1
        };
        wpe.AddToPosts(p);
        p.City = city;
        p.Category = category;
        wpe.SaveChanges();
