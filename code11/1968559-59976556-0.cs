    public class Image
    {
        public int FileName {get;set;}
        public bool Shown {get;set;}
        public string Src => Shown ? $"{FileName}.jpg" : "0.jpg";
    }
Next, we need to create a collection of items. This could be static, come from a data source like a database, etc. In this example I'll use the Enumerable.Range function to generate a list of values ranging from 1-10. The Select method will assign those values to a new Image setting the FileName value. The values are stashed in a list.
List<Image> items = Enumerable.Range(1, 10).Select(i => new Image { FileName = i}).ToList();
In the UI portion, we need to render some markup. An image would work fine here, but a button was easier for example purposes. In the onclick event, we simply set the Shown value to true. Setting this value updates the Src property displaying the "shown" image, 1-10.jpg.
@foreach (var item in items) {
    <button @onclick="@(()=> item.Shown = true)">@item.Src</button>
}
Putting it all together you have:
@foreach (var item in items) {
    <button @onclick="@(()=> item.Shown = true)">@item.Src</button>
}
@code {
    List<Image> items = Enumerable.Range(1, 10).Select(i => new Image { FileName = i}).ToList();
    public class Image
    {
        public int FileName {get;set;}
        public bool Shown {get;set;}
        public string Src => Shown ? $"{FileName}.jpg" : "0.jpg";
    }
}
You can replace the button with an image for your task.
<img src="@item.Src" @onclick="@(()=> item.Shown = true)" />
See the solution working live here
https://blazorfiddle.com/s/m01smajj
