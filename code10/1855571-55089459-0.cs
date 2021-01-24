C#
public class SurveyForm
{
    [JsonProperty("pages")]
    public IEnumerable<SurveyPage> Pages { get; set; } 
}
public class SurveyPage
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("elements")]
    public IEnumerable<SurveyPageElement> Elements { get; set; }
}
public class SurveyPageElement
{
    // I think you can do the rest
}
public class SurveyResult
{
    // same as the other classes
}
Do you notice the `JsonProperty` Attribute? Use that to tell json.NET where to find the related properties in your json. You actually don't need to do that because json.NET does some magic to find the correct properties by it's own but I think it is useful to do it by my own.
Then deserialize the two Jsons:
C#
var surveyForm = JsonConvert.DeserializeObject<SurveyForm>(surveyFormJson);
var surveyResult = JsonConvert.DeserializeObject<IEnumerable<SurveyResult>>(surveyResultJson);
