[Authorize(Roles = "Admin, User")]
[HttpPost]
[Route("api/postall/datatobesent")]
public IHttpActionResult PostAllDataToBeSent([FromBody] List<DataToBeSent> dataToBeSent)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
    foreach(var data in dataToBeSent)
    {
        db.DataToBeSent.Add(data);
    }
    try
    {
        db.SaveChanges();
        return Ok();
    }
    catch (Exception)
    {
        throw;
    }
}
Thank you to all who commented and contributed. 
