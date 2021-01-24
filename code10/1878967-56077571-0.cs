c#
    public class Root
    {
        public string code { get; set; }
        public string message { get; set; }
        public Item[] items { get; set; }
    }
Then in your already existing **Item** class you add or remove the desired properties. I used the class that you've provided.
Then you do this:
c#
var inputObj = JsonConvert.DeserializeObject<Root>(json);
**json** in the above code is string variable holding the whole JSON, provided by you. Please note in you provided json there is a missing "}" at the end.
**inputObj** is an object of type Root class and contains an array of all items.
E.g inputObj.items
[![enter image description here][1]][1]
If you need more help comment below.
Cheers
  [1]: https://i.stack.imgur.com/f551E.png
