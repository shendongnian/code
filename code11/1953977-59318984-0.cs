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
Hope this helps
