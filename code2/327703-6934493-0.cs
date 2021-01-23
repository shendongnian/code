       public Teacher GetClassTeacher()
       {
           var teacher = Session["Teacher"] as Teacher
           if (teacher == null)
           {
                //Get Teacher Info from Database
           }   
       }
