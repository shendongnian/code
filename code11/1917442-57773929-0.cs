[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class FromHeaderModelAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider
{
		public BindingSource BindingSource => BindingSource.Query;
		public string Name { get; set; }
}
So, final result is: 
[HttpGet]
[Route("headers")]
public ActionResult<string> Get([FromHeaderModel] HeadersParameters parameters = null)
{
	return JsonConvert.SerializeObject(parameters);
}
public class HeadersParameters
{
	[FromHeader]
	[Required]
	public string Header1 { get; set; }
	[FromHeader]
	public string Header2 { get; set; }
}
