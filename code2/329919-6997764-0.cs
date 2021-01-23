        public ActionResult IndexStudents(Docent docent, int lessonid, int classid)
        {
            ViewData["list1"] = new SelectList(docent.ReturnStudentsNormalAsString(lessonid, classid)));
            ViewData["list2"] = (new SelectList(docent.ReturnStudentsNoClassAsString(lessonid, classid)));
            return View();            
        }
