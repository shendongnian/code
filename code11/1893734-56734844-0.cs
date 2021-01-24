           [HttpPost]
        public JsonResult AddComment(int id_usr,string comment)
        {
            if (ModelState.IsValid)
            {
                Comments kom = new Comments();
                kom.DateComment = DateTime.Now;
                kom.Id_usr = id_usr;
                kom.Comment = comment;
                db.Comments.Add(kom);
                db.SaveChanges();
                return Json(kom);
            }
            return Json(null);
        }
