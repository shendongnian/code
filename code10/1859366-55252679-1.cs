C#
var arr = JsonConvert.DeserializeObject<JArray>(serialized);
for(var i = 0;i < arr.Count; i++)
{
    JArray arr2 = arr[i] as JArray;
    for(var j = 0;j < arr2.Count; j++)
    {
        JObject obj = arr2[j] as JObject;
        // using dynamic 
        dynamic dobj = obj;
        var Id = (int)doObj.Id;
       // using strong type
       var strongObj = obj.ToObject<MyClientClass>()
    }
}
-----------------
> Should I duplicate the RsTarget on the client? What if the API changes the RsTarget
The best way to duplicate the RsTarget on the client. and for your second question :  It alway break your app when api chages the property name even if you use `JObject` , but if only add a property, they both won't be effected.
