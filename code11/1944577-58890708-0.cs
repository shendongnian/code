    public ActionResult Create(StudentDetails studentDetails)
    {
        using (StudentRecordManagementEntities1 obj = new StudentRecordManagementEntities1())
        {
            var studentDetail = new StudentRecordManagement.Models.StudentDetail {
             Name = studentDetails.Name,
             // the other code is omitted for the brevity
         };
         obj.StudentDetails.Add(studentDetail);  //
    }
