    [HttpPost]
    public IActionResult GetFilterOptions([FromBody] checkedValues[])
    {   
        var selectedItems  = checkedValues[];
        foreach (item in selectedItems)
        {
        }
        
        //var test = db.testsample.tolist();
        //if(!string.isNullOrEmpty(model.param1))
        //{
        //   test = test.where( x => x.param1 == model.param1)
        //}
        return Ok(new { result= test });
    }
