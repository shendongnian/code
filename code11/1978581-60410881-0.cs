`
public class MyParamModel
{
	public string OPDNo { get; set; }
	public string VAFRE { get; set; }
	public string VAFLE { get; set; }
}
`
1 - Make sure the property names match between the ``javascript`` and the ``C#`` model.
2 - Make sure the model properties are public.
3 - Change the signature of your action to : 
`
[HttpPost]
public void SaveVisionScreening(MyParamModel formArray , string[] selectValues)
{
	//Code...
}
`
I hope this will help you out.
