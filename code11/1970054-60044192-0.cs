 lang-cs
// Default options for wwwroot
app.UseStaticFiles();
// Set up FileExtension Content Provider for Web Assembly
var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".wasm"] = "application/wasm";
app.UseStaticFiles(new StaticFileOptions
{
	ContentTypeProvider = provider,
	ServeUnknownFileTypes = true,
	DefaultContentType = "application/octet-stream",
	FileProvider = new PhysicalFileProvider(
		Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WebAssemFiles")),
	RequestPath = "/WebAssemFiles"
});
