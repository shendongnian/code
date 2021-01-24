    public class ApiInputModel
    {
      public MyStatusEnum Status {get; set;}
     }
     
    [HttpPost]
     public IActionResult Test([FromBody] ApiInputModel model)
     {
            var statuses = Enum.GetNames(typeof(MyStatusEnum)).ToList();
            if (model.Status == MyStatusEnum.FinishedStepC)
            return Ok(statuses.Where(x => x.Contains("FinishedStep")));
            else
             return Ok();
      }
