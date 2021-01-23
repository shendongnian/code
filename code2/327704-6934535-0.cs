        public static Teacher GetClassTeacher()
        {
            Teacher teacher = HttpContext.Current.Session["Teacher"] as Teacher;
            if (teacher == null)
            {
                //Get Teacher Info from Database
                teacher = GetTeacherFromDB();
                HttpContext.Current.Session["Teacher"] = teacher;                
            }
            return teacher;
        }
