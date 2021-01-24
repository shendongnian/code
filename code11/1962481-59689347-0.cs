static void Main(string[] args)
{
    // parse the JSON results of the API Call
    JObject apiResult = JObject.Parse(File.ReadAllText("JsonBlock.json"));
    // iterate through the models
    foreach (var model in apiResult["Cars"].Children<JProperty>().Select(i => i.Name))
        // GM cars have a submodel
        if(model.Equals("GM",StringComparison.CurrentCultureIgnoreCase)) 
        {
            foreach (var submodel in apiResult["Cars"][model].Children<JProperty>().Select(i => i.Name))
                AddCar(submodel,apiResult["Cars"][model][submodel]);
        } 
        else
            AddCar(model,apiResult["Cars"][model]);            
}
static void AddCar(string model, JToken cars)
{
    switch(model)
    {
        case "Honda":                    
            // do honda things
            break;
        case "Toyota":
            // do toyota things
            break;
        case "Chevrolet":
            // do chevy things
            break;
        default:
            throw new NotImplementedException();
    }            
}
