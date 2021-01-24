`
public class RootObject // You can name this whatever you want
{
    public Properties properties { get; set; }
}
public class Metadata
{
	public string assignedBy { get; set; }
}
public class RingValue
{
	public List<string> value { get; set; }
}
public class Parameters
{
	public RingValue ringValue { get; set; }
}
public class Properties
{
	public string displayName { get; set; }
	public string description { get; set; }
	public Metadata metadata { get; set; }
	public string policyDefinitionId { get; set; }
	public Parameters parameters { get; set; }
	public string enforcementMode { get; set; }
}
`
Now, we can easily do the logic you need as follows:
`
// This is your json string, escaped and turned into a single string:
string file = "{  \"properties\": {    \"displayName\": \"jayatestdefid\",    \"description\": \"test assignment through API\",    \"metadata\": {      \"assignedBy\": \"xyz@gmail.com\"    },    \"policyDefinitionId\": \"/providers/Microsoft.Management/managementgroups/MGTest/providers/Microsoft.Authorization/policyDefinitions/test\",    \"parameters\": {      \"ringValue\": {        \"value\": [\"r0\"]      }    },    \"enforcementMode\": \"DoNotEnforce\",    }}";
// Convert your json string into an instance of the RootObject class
RootObject jobject = JsonConvert.DeserializeObject<RootObject>(file);
// Get a list of all the "values"
List<string> values = jobject.properties.parameters.ringValue.value;
// Loop over your colleciton of "value" and do your logic
for (int i = 0; i < values.Count; ++i)
{
	if (values[i] == "r0")
	{
		values[i] = "r0,r1";
	}
}
// And finally, turn your object back into a json string
var result = JsonConvert.SerializeObject(jobject);
`
And this is the final result:
`
{ 
   "properties":{ 
      "displayName":"jayatestdefid",
      "description":"test assignment through API",
      "metadata":{ 
         "assignedBy":"xyz@gmail.com"
      },
      "policyDefinitionId":"/providers/Microsoft.Management/managementgroups/MGTest/providers/Microsoft.Authorization/policyDefinitions/test",
      "parameters":{ 
         "ringValue":{ 
            "value":[ 
               "r0,r1"
            ]
         }
      },
      "enforcementMode":"DoNotEnforce"
   }
}
`
