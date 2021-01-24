    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AllocateClassRoom allocateClassRoom)
        {
                string subID = Request.Form["SubjectID"].ToString();
                var subject = db.Subjects.Where(s => s.Code == subID).FirstOrDefault();
                int departmentID = Convert.ToInt32(subject.DepartmentId);
                int CourseID = Convert.ToInt32(subject.SubCourForId);
                int SubjectID = subject.SubjectID;
                string roomNo = Request.Form["RoomId"].ToString();
                var room = db.Rooms.Where(s => s.RoomNo == roomNo).FirstOrDefault();
                int roomID = room.Id;
                allocateClassRoom.DepartmentId = departmentID;
                allocateClassRoom.CourseId = CourseID;
                allocateClassRoom.SubjectID = SubjectID;
                allocateClassRoom.RoomId = roomID;	
    
               allocateClassRoom.StartTime = DateTime.ParseExact(allocateClassRoom.From, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
               allocateClassRoom.FinishTime = DateTime.ParseExact(allocateClassRoom.To, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
    
             db.Entry(allocateClassRoom).State = System.Data.Entity.EntityState.Modified;
             db.SaveChanges();
             return RedirectToAction("Index");
        }
