csharp
[HttpPost("SavePost")]
public async Task<IActionResult> SavePost([FromForm]PostViewModel viewModel)
{
	var postOptionsViewModel = _jsonParsePostOptionDefaultVm.ToObject(viewModel.PostOptionsViewModel);
	viewModel.PostOptionsDefaultViewModel = postOptionsViewModel;
	if (viewModel.Id.HasValue)
	{
		await _postRepository.EditPost(viewModel);
	}
	else
	{
		await _postRepository.SavePost(viewModel);
	}
	return Ok();
}
My model will have property like this
csharp
public List<IFormFile> File { get; set; }
My FE side code will be like this. I'm using react but mostly not different in the way we submit a formdata to server
javascript
const formdata = new FormData();
formdata.append("Title", this.state.title);
formdata.append("File", this.state.File);
Remember to set Content-Type header to 'multipart/form-data'
