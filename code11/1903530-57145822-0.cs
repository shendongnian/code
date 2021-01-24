 c#
[HttpPost]
[ResponseType(typeof(IEnumerable<Student>))]
public IHttpActionResult Find([FromBody]SearchType searchType,[FromUri]string searchText)
{
    //EF code to get data from DB
    using (handler)
    {
        return Ok(handler.Find(searchText, searchType));
    }
}
 c#
string aSearchText ="John";
     SearchType aSearchType = SearchType.Name; //this is enum
     Task<HttpResponseMessage> responseTask = client.PostAsJsonAsync($"api/Student/{aSearchText}",aSearchType );
     responseTask.Wait();
