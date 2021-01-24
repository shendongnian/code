    [Authorize(Roles = "Admin,Teacher")]
            [HttpDelete("api/classes/DeleteClass")]
            public ActionResult DeleteClass(string ClassId)
            {
    //Do Something
    }
