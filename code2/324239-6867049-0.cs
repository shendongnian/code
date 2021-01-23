    String selectedColor = "blue";
    using(DataContext db = new DataContext())
    {
       ListView1.DataSource = db.Cars.Where(m => m.Cars.color == selectedColor);
       ListView1.DataBind();
    }
