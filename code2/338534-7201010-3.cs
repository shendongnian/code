        var test = "Donald,Duck\nMickey,Mouse";
        var data =
           test.Split('\n')
           .Select(line => line.Split(','))
           .Select(columns => new { FirstColumnName = columns[0], SecondColumnName = columns[1] /*, ... */});
        GridView1.DataSource = data;
        GridView1.DataBind();
