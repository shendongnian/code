public static void ManipulateJsonObject()
{
	string json =
	@"{
		""empleado"": {
			""nombre"": ""My nombre"",
			""apellido"": ""My apellido"",
			""edad"": 1
		}
	}";
	JObject baseJObject = JObject.Parse(json);
	System.Diagnostics.Trace.WriteLine("JObject before modifications, just after parse:");
	System.Diagnostics.Trace.WriteLine(baseJObject.ToString());
	// Get node with name 'empleado'
	JObject empleadoNode = (JObject)baseJObject["empleado"];
	// Create new property 'afterNombre'
	empleadoNode.Property("nombre").AddAfterSelf(new JProperty("afterNombre", "new nombre value"));
	System.Diagnostics.Trace.WriteLine("Observe newly added property 'afterNobre':");
	System.Diagnostics.Trace.WriteLine(baseJObject.ToString());
	// Read value of new property 'afterNombre'
	string empleadoValue = (string) empleadoNode["afterNombre"];
	// Throws exception if value was not set
	if(string.IsNullOrWhiteSpace(empleadoValue))
		throw new Exception("Adding or Reading new property failed");
	// Update value of existing property 'edad'
	empleadoNode["edad"] = 3;
	System.Diagnostics.Trace.WriteLine("Observe newly property 'edad' has been updated:");
	System.Diagnostics.Trace.WriteLine(baseJObject.ToString());
	// Delete newly added property 'afterNombre'
	empleadoNode.Property("afterNombre").Remove();
	System.Diagnostics.Trace.WriteLine("Observe property 'afterNobre' has been deleted:");
	System.Diagnostics.Trace.WriteLine(baseJObject.ToString());
	// Output final object
	System.Diagnostics.Trace.WriteLine("Final state of JObject:");
	System.Diagnostics.Trace.WriteLine(baseJObject.ToString());
}
See visual studio Output window for inspection result after each manipulation.
