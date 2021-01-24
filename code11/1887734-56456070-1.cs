[HttpGet]
<b>[ServiceFilter(typeof(AddPaginationHeader))]</b>
public async Task<IActionResult> Get([FromQuery]PagingModel pagingModel, [FromHeader(Name = "Accept")]string mediaType) 
{
    ....
}
