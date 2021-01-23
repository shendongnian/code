    var data =
       File.ReadAllLines(Server.MapPath("~/MyPlace"))
       .Select(line => line.Split(',')
       .Select(columns => new {FirstColumnName = columns[0], SecondColumnName = columns[1] /*, ... */});
    myGridView.DataSource = data;
    myGridView.DataBind();
