public class ActualValue
{
    public int valuetoExtract1 { get; set; }
 
}
ActualValues actualValues = new ActualValues();
JObject jsonO = JObject.Parse(json);
var converterJsonO = jsonO["actualValues"];
var oList = converterJsonO .Children();
            
foreach(JObject childObject in oList)
    {
        var d = childObject.ToObject<Dictionary<string, string>>();
        if (d.ContainsKey("valuetoExtract1")) { actualValues.valuetoExtract1= int.Parse(d["valuetoExtract1"]); }
    }
