    [Authorize(Policy = "TeacherSubject")]
    public ActionResult<Subject> GetSubjectDetails(int subjectId)
    {
        //existing code
    }
