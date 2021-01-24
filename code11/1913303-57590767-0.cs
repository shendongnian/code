c#
[HttpPost]
public void Post([FromBody] Person person)
{
	try 
	{
		bll.AddNumber(person);
	}
	// Replace with own exception
	catch (FormatException e)
	{
		return new HttpResponseMessage(HttpStatusCode.BadRequest)
		{
			ReasonPhrase = "Phone number is not correctly formatted"
		};
	}
	return new HttpResponseMessage(HttpStatusCode.OK);
}
