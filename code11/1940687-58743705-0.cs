`
[HttpGet]
public IActionResult Get([FromQuery]DateTime? dateTime)
{
    if (dateTime.HasValue)
    {
        // get by date
    }
    else
    {
        // get all
    }
}
        
[HttpGet("{id}")]
public IActionResult Get(int id)
{
    // get by id
}
`
All three of these URL's can now be hit:
    https://localhost:44341/api/Orders
    https://localhost:44341/api/Orders/3
    https://localhost:44341/api/Orders?dateTime=2019-11-01T00:00:00
