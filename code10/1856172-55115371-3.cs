    public IHttpActionResult Put(int id, Student student)
    {
         ModelState.Remove(nameof(student.Standard.StandardName));
         if (ModelState.IsValid && id == student.StudentId) {
        ...
    }
