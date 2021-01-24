    [HttpGet]
    public ActionResult Edit(int ID)
    {
        using (UniversityDbContext db=new UniversityDbContext())
        {            
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Code");
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Code");               
            ViewBag.DepartmentId = db.Departments.ToList();
           
            AllocateClassRoom allocateClassRoom = new AllocateClassRoom();
            allocateClassRoom.DepartmentId = getAllocationDetails.DepartmentId;
            allocateClassRoom.CourseId = getAllocationDetails.CourseId;
            allocateClassRoom.SubjectID = getAllocationDetails.SubjectID;
            allocateClassRoom.RoomId = getAllocationDetails.RoomId;
            allocateClassRoom.date = getAllocationDetails.date;
            allocateClassRoom.Day = getAllocationDetails.Day;
            allocateClassRoom.From = getAllocationDetails.From;
            allocateClassRoom.To = getAllocationDetails.To;
            allocateClassRoom.StartTime = getAllocationDetails.StartTime;
            allocateClassRoom.FinishTime = getAllocationDetails.FinishTime;
			
			var allocateClassRooms = db.AllocateClassRooms.Include(a => a.Course).Include(a => a.Department).Include(a => a.Subject).Include(a => a.Room).ToList();
            var getAllocationDetails = db.AllocateClassRooms.Where(s => s.Id == ID).FirstOrDefault();
            Department department = new Department();
            var departmnt = db.Departments.Where(s => s.ID == getAllocationDetails.DepartmentId).FirstOrDefault();
            ViewData["DepartmentData"] = departmnt.Code;
            var course = db.Courses.Where(s => s.Id == getAllocationDetails.CourseId).FirstOrDefault();
            ViewData["CourseData"] = course.Code;
            var subject = db.Subjects.Where(s => s.SubjectID == getAllocationDetails.SubjectID).FirstOrDefault();
            ViewData["subjectData"] = subject.Code;
            var room = db.Rooms.Where(x => x.Id == getAllocationDetails.RoomId).FirstOrDefault();
            ViewData["roomData"] = room.RoomNo;
            ViewData["DayValue"] = getAllocationDetails.Day;
            return View(allocateClassRoom);
        }
    }
