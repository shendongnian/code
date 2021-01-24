    var jobj = JObject.Parse(jsonString);
    List<Phase> Phases = new List<Phase>();                
    var complexity = jobj.SelectToken("complexity");
    var childrens = complexity.Children().ToList();
    for (int i = 1; i < childrens.Count; i++)
    {
        var activities = new List<Activity>();
        var _properties = new List<Dictionary<string, string>>();
        var child = childrens[i].Children();//getting all the sub-documets in the json
        foreach (var subChild in child)
        {
           var phases = subChild.SelectToken("phases").Children().ToList();//getting JTokens having key "phases"
           for (int j = 1; j < phases.Count; j++)
           {
              var phaseResult = phases[j].Children().ToList(); //getting all the children of the //phases JToken and itterating over them
              foreach (var item in phaseResult)
              {
                 if (item["activities"] != null) //producing the "Activity(s)" object
                 {
                    var acts = item.SelectToken("activities").Children().ToList();
                    for (int k = 1; k < acts.Count; k++)
                    {
                       var act = acts[k].Children().ToList();
                       foreach (var entity in act)
                       {
                          var jarvalue = JArray.Parse(entity.ToString()).Children().ToArray()[0].ToString();
                          var objAct = JsonConvert.DeserializeObject<Activity>(jarvalue);
                          activities.Add(objAct);
                       }
                    }
                 }
                 else
                 {
                    //if not Activity object than producing Properties object
                    var _props = item.Children<JToken>().ToList();
                    var nProeprties = new Dictionary<string, string>();
                    foreach (var content in _props)
                    {
                       var _contentProp = ((Newtonsoft.Json.Linq.JProperty)content); //converting the property object of JtokenType to JProperty to get the Name and JValue
                                        nProeprties.Add(_contentProp.Name, _contentProp.Value.ToString());                                        
                    }
                    _properties.Add(nProeprties);
                 }
              }
           }
        }
        Phases.Add(new Phase { Activites = activities, Properties = _properties });//appending the extracted output to the mail object "Phases"
     }
