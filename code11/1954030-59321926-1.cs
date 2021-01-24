  public async Task<List<GrTables>> GetPaginatedResult(int pageSize, int pageNumber)
          
  {
            var query = _doc.Set<GrTables>().AsQueryable();
            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
  }
I also like to return the paginated data with info that helps to process and request more paginated data.
 public class PageMetadata
 {
        public int TotalRecordCount { get; set; }
        public string NextPageLink { get; set; }
        public string PreviousPageLink { get; set; }
        public string FirstPageLink { get; set; }
        public string LastPageLink { get; set; }
        public int ActualPage { get; set; }
        public int RecordsPerPage { get; set; }
        public int TotalPages { get; set; }
 }
 public class PagedResponse<TResponseModel>
 {
        public IEnumerable<TResponseModel> Records { get;  set; }
        public PageMetadata Metadata { get;  set; }
 }
[HttpGet]
public async Task<IActionResult> GetPagedServiceData(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize)
{
            var result  = await new Documentation().GetPaginatedResult(pageNumber, pageSize);
            return Ok(result);
}
