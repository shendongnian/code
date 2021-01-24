public class Model
{
    public int TS;
    public Update[][] Updates;
}
public class Update
{
    public int? Number;
    public string Word;
    public ModelDictionary Dictionary;
}
public class ModelDictionary
{
    public string Title;
    public string Type;
}
Then you could access each `Update` with something like
if (Number != null) { ... }
else if (Word != null) { ... }
else if (Dictionary != null) { ... }
Also, https://app.quicktype.io/ is always a great resource for generating C# models from JSON objects.
