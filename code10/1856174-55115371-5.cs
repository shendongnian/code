    [HttpPut, Route("updateStudent/{id:int}")]
    public IHttpActionResult Put(int id, StudentViewModel student)
    {
        if (ModelState.IsValid && id == student.StudentId) {
        ...
        // map with your Student Entity here  as per your needs
        }
    }
