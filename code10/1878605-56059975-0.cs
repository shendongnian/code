    if (ModelState.IsValid)
            {
                kursister.note = kursister.note + DateTime.Now().ToString();
                db.kursister.Add(kursister);
                db.SaveChanges();
                return RedirectToAction("../kursus_kursist/Create/" + kursister.kursist_id);
            }
