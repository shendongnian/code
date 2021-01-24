    public IHttpActionResult Put(int id, Student student)
    {
         // ignore StandardName property
         ModelState.Remove(nameof(student.Standard.StandardName));
         if (ModelState.IsValid && id == student.StudentId) {
        ...
    }
