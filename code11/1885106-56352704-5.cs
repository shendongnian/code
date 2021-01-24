     [HttpPost]
        public async Task<IActionResult> InsertStudents([FromBody]StudentViewModel studentVM)
        {
            List<StudentInfo> model = studentVM.StudentInfos;
            _context.AddRange(model);
            int insertedRecords=await _context.SaveChangesAsync();
            return Json(insertedRecords);
            
        }
