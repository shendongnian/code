    [HttpGet]
    public IActionResult GetFilterOptions([FromBody] CheckboxObject model)
    {   
        
        foreach (item in selectedItems)
        {
            //Query Statement goes here
        }
        
      
        return Ok(new { result= test });
    }
    public class CheckboxObject
    {
       public List<string> CheckedValues;
    }
