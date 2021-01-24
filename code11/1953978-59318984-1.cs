public async Task<IActionResult> OnGetTableAsync()
{
   var wItem = await _detailRepo.Finddetail(CancellationToken.None);
   //string NewtonJSON = JsonConvert.SerializeObject(wItem);
   return Content(wItem );
}
I think you may want to change the return type to OK:
public async Task<IActionResult> OnGetTableAsync()
{
   var wItem = await _detailRepo.Finddetail(CancellationToken.None);
   return Ok(wItem );
}
And return a list (to fit into the table)
public async Task<IActionResult> OnGetTableAsync()
{
   var wItem = await _detailRepo.Finddetail(CancellationToken.None);
   return Ok(new List<object> {wItem} );
}
I believe this should return something like: 
[{
   "detail_ID": 7,
   "detail_GUID": "685b8741-fe22-460a-bb76-7ecd9c320172"
}]
Which should be more compatible with tables 
You may have to also change the "ajax" part of the ajax call:
"ajax": {
    "url": "/Index?handler=Table",
    "type": "GET",
    "dataType": "application/json"
}
Update: Looks like you need to return specific object looking at the example [Here](https://datatables.net/examples/server_side/simple.html)
So you need to make your object look like this:
{
    "data": [{
        "detail_ID": 7,
        "detail_GUID": "685b8741-fe22-460a-bb76-7ecd9c320172"
    }]
}
The easiest way to do this is probably going to be to update your server-side do something like:
public async Task<IActionResult> OnGetTableAsync()
{
   var wItem = await _detailRepo.Finddetail(CancellationToken.None);
   return Ok(new { data = new List<object> {wItem} });
}
I believe there is a .Net nuget package for data table that will give you a more appropriate type to return
Hope this helps
