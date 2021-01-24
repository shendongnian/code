namespace JsonStuff
{
    public class SomeParentClass
    {
        public Addition AdditionObject { get; set; }
        public SomeParentClass()
        {
        }
    }
}
If you try it the other way serializing an object from type "Addition" and have a look on the outcoming json string, you will see the difference:
var filledObject = new Addition()
{
    Easy = new List<string>()
    {
        "New York Bulls",
        "Los Angeles Kings",
        "Golden State Warriros",
        "Huston Rocket"
    },
    Medium = new List<string>()
    {
        "New York Bulls",
        "Los Angeles Kings",
        "Golden State Warriros",
        "Huston Rocket"
    },
    Difficult = new List<string>()
    {
        "New York Bulls",
        "Los Angeles Kings",
        "Golden State Warriros",
        "Huston Rocket"
    }
};
var serializedObject = JsonConvert.SerializeObject(filledObject);
The result will be:
{
	"Easy":
	[
		"New York Bulls",
		"Los Angeles Kings",
		"Golden State Warriros",
		"Huston Rocket"
	],
	"Medium":
	[
		"New York Bulls",
		"Los Angeles Kings",
		"Golden State Warriros",
		"Huston Rocket"
	],
	"Difficult":
	[
		"New York Bulls",
		"Los Angeles Kings",
		"Golden State Warriros",
		"Huston Rocket"
	]
}
and there you see the difference: There is no "Addition" property on top.
