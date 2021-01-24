    using System.Web.Script.Serialization;
    [HttpPost]
    public ActionResult CreateStudent(string json)
    {
      var serializer = new JavaScriptSerializer();
      dynamic jsondata = serializer.Deserialize(json, typeof(object));
      //Get your variables here from AJAX call
      var schoolname= jsondata["schoolname"];
      var studentname= jsondata["studentname"];
      var joindate= jsondata["joindate"];
        
      studentdb student=new studentdb();
      student.school_name=schoolname;
      student.join_date=Convert.ToDateTime(joindate);
      string[] splitstr = studentname.Split(',');    
      foreach(string s in splitstr)
      {
         student.student_name=s;
         db.studentdb.Add(student);
      }
    
      db.SaveChanges();
    
      return RedirectToAction("Index", "Create");
    }
