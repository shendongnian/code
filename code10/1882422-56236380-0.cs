c#
[HttpPost]
public ActionResult GraphMethod([FromForm]string str)
{ 
    // These two if statements can be concatenated into one, 
    // but that would be a bit hard to read
    if (this._copyManager.TryCreateCopy(str, out var affectedRows))
        if (affectedRows > 1)
            return Ok();
    return BadRequest("Error!");
}
// _copyManager Method, there's probably a better way for you
public bool TryCreateCopy(string str, out int affectedRows)
{
    try
    {
        affectedRows = CreateCopy(str);
    }
    // Please also don't do `catch (Exception)`, 
    // if you know which exception gets thrown always catch that
    catch (Exception e)
    {
        affectedRows = -1;
        return false;
    }
    
    return true;
}
Where the TryCreateCopy method returns true when a copy was created without an exception being thrown, false if one has been thrown* and an out variable with the number of affected rows
----------
\* There is probably a better way of doing this than what I showed you (e.g validate method?) as try/ catch is quite resource intensive
