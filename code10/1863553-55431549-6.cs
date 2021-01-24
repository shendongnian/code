    public JsonResult GetVoters()
    {
     DataTable dataTable = new DataTable();
     List<vt> stud = (from student in _context.Voters
                          select new vt
                          {
                              StudentNumber = student.StudentNumber,
                              Name = student.Name,
                              Faculty = student.Faculty,
                              Department = student.Department,
                              Program = student.Program,
                              Code = student.Code
                          }).Take(100).ToList();
        //The magic happens here
        dataTable.data = stud;
        return Json(dataTable, JsonRequestBehavior.AllowGet);
      }
