    using (PlanetWroxEntities myEntities = new PlanetWroxEntities())
    {
        var allGenres = from genre in myEntities.Genres
        orderby genre.Name
        select new { genre.Name, genre.Reviews };
        GridView1.DataSource = allGenres.ToList();
    }
