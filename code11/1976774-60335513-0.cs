csharp
Localized<string> name = ...;
switch(language)
{
    case "en":
        return name.en;
    case "ar":
        return name.ar;
    case "fr":
        return name.fr;
    default:
        throw new LocalizationException();
}
which is error-prone and overly complicated. For your problem, I think I'd opt to use some kind of dictionary
csharp
IDictionary<string, string> names = ...;
if(names.ContainsKey(language))
{
    return names[language];
}
else 
{
    throw new LocalizationException();
}
which is easily extensible by just adding more translations to the dictionary.
To convert your JSON `string` to an `IDcitionary<string, string>`, you could use the following code
csharp
localizedNames = JObject.Parse(Name)
                        .Children()
                        .OfType<JProperty>()
                        .ToDictionary(property => property.Name, 
                                      property => property.Value.ToString());
From within your class this would effectively be
public class Place
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    
    public Dictionary<string, string> LocalizedNames 
    {
        get
        {
            return JObject.Parse(Name)
                          .Children()
                          .OfType<JProperty>()
                          .ToDictionary(property => property.Name, 
                                        property => property.Value.ToString());
        }
    }
}
The localized values can be accessed like 
var localizedPlaceName = place.LocalizedNames[language];
**Please note**: Depending on your needs and use cases, you should consider the following issues:
### Caching
In my snippet, the JSON `string` is parsed **every time** the localized names are accessed. Depending on how often you access it, this might be detrimental to performance, which could be mitigated by caching the result (don't forget to delete the cache when `Name` is set). 
### Separation of concerns
The class as is is supposed to be a pure model class. You might want to introduce domain classes that encapsulate the presented logic, rather than adding the logic to the model class. Having a factory that creates readily localized objects based on the localizable object and the language could be an option, too. 
### Error handling
In my code there is no error handling. Depending on the reliability of input you should consider additional error handling.
