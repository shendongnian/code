    EQCN = Request.QueryString["EQCN"];
    var query = from n in db.equipments
                 where n.EQCN.ToString() == EQCN
                 select new { n.Name, n.Description, n.Title };
    // Or possibly Single, or First...
    var projection = query.Single();
    textBox1.Text = projection.Name;
    textBox2.Text = projection.Description;
    textBox3.Text = projection.Title;
