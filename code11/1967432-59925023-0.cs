private readonly MyService _myService;
public IndexModel(MyService myService)
{
	_myService = myService;
}
public async Task<IActionResult> OnPostAddAsync()
{
	_myService.Add(1);
}
