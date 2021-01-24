    public IActionResult GetTypesBasedOnValueFromOtherDropDownList(string Type)
    {
        //you can query database instead 
        List<AdmInstCourses> admInstCourses = new List<AdmInstCourses>();
        admInstCourses.Add(new AdmInstCourses() { CourseCode = 1, CourseName = "name1", Units = "3.2" });
        admInstCourses.Add(new AdmInstCourses() { CourseCode = 2, CourseName = "name2", Units = "3.3" });
                
        return new JsonResult(admInstCourses);
    }
