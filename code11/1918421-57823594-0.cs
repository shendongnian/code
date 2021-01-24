            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "id,name,winner,points,postDate")] Pick pick)
            {
            if (ModelState.IsValid) 
            {
         
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Picks WHERE [score] = 
            @score AND [winner] = @winner", con);
            SqlDataAdpater _dt=new SqlDataAdpater(cmd);
            cmd.Parameters.AddWithValue("@score", pick.points);
            cmd.Parameters.AddWithValue("@winner", pick.winner);
            DataTable  _dt=new DataTable();
           _dt.fill(_dt);
           if(_dt.Rows.Count>0)
            {
                db.Picks.Add(pick);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        return View(pick);
    }
