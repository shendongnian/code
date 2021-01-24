        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,winner,points,postDate")] Pick pick)
        {
            
            if (ModelState.IsValid) 
            {
                SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Picks p WHERE p.score = @score AND p.winner = @winner", con);
                
                cmd.Parameters.AddWithValue("@score", points);
                cmd.Parameters.AddWithValue("@winner", winner);
                var count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    db.Picks.Add(pick);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(pick);
        }
