    @if (items != null)
    {
        @foreach (var item in items)
        {
            <div class="@RenderDomClass(item.Id)" @onclick="_ => ChangeColor(item.Id)">@item.Id</div>
        }
    }
    
    @functions{
        //Instead of these Mock data you should load your own data
        IList<Foo> items = new List<Foo>()
             {
                new Foo { Id =1, DomClasses=new List<string>(){string.Empty}},
                new Foo { Id =2, DomClasses=new List<string>(){string.Empty}},
                new Foo { Id =3, DomClasses=new List<string>(){string.Empty}},
                new Foo { Id =4, DomClasses=new List<string>(){string.Empty}},
                new Foo { Id =5, DomClasses=new List<string>(){string.Empty}},
                new Foo { Id =6, DomClasses=new List<string>(){string.Empty}},
    
            };
    private void ChangeColor(int id)
    {
        var domClasses = items.SingleOrDefault(item => item.Id == id).DomClasses;
        if (domClasses.Contains("red"))
        {
            domClasses.Remove("red");
        }
        else
        {
            domClasses.Add("red");
        }
        RenderDomClass(id);
    }
    private string RenderDomClass(int id)
    {
        var domClass = string.Empty;
        var domClasses = items.SingleOrDefault(item => item.Id == id).DomClasses;
        if (domClasses.Count > 0)
        {
            foreach (var item in domClasses)
            {
                domClass += $" {item}";
            }
        }
        return domClass;
    }
    public class Foo
    {
        public int Id { get; set; }
        public List<string> DomClasses { get; set; }
    }
    }
