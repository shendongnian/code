c#
[HttpGet]
[Obsolete("Use Execute with bool? someNewName instead.")]
public async Task<IActionResult> Execute(bool? someName)
{
}
[HttpGet]
public async Task<IActionResult> Execute(bool? someNewName)
{
}
If you only changed the name of the parameter, you can instead use the `Bind` attribute to bind a URI element to a differently named variable, like so:
c#
[HttpGet]
public async Task<IActionResult> Execute([Bind(Prefix = "someNewName")] bool? someName)
{
}
This would allow you to continue to use the same method, without having to forcibly change all your clients. But, if more than just the name of the parameter changed, for example the type, you'll need a new method
