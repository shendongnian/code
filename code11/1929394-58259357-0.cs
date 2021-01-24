[HttpGet]
public async Task<ActionResult<string>> Test()
{
	try
	{
		//var tl1 = new TL1Context();
		//OnuAuthService.Test();
		var tl1 = Task.Run(() => new TL1Context());
		var TL1ContextOutput = await tl1;
	}
	catch (Exception e)
	{
		return BadRequest(e);
		throw;
	}
	return Ok();
}
