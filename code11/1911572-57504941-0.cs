        string Subject_Code = "";
        string Subject_Name = "";
        if (String.IsNullOrEmpty(Subject_Code) && String.IsNullOrEmpty(Subject_Name)){
            return NotFound();
        } else{
            return Ok();
        }
