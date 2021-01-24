 csharp
public class MyObject{
	public bool Estado { get; set; }
	public Guid Token { get; set; }
	public string Nombre { get; set; }
}
Then you can use Json.Net to deserialize it.
 csharp
var json = "{\"Estado\":true,\"Token\":\"3D16C8D8-058C-4FA7-AEA2-1A764A083B72\",\"Nombre\":\"Agente COV\"}";
var myObject = JsonConvert.DeserializeObject<MyObject>(json);
Then access the values like `myObject.Token` etc.
