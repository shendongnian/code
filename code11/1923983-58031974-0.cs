    [HttpDelete]
    public IActionResult Delete([FromRoute]int requestId)
    {
        requestApiService.Delete(requestId);
        return NoContentResult();
    }
    //service
    public void Delete(long requestId, int platformClientId)
    {
        //some logic here
    }
    //service
    public void Delete(int requestId, int platformClientId)
    {
       throw new ArgumentException();
    }
