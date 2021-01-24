    // controller
    public IActionResult Index()
    {
        var json = System.IO.File.ReadAllText("pathtojson");
        TodoItem data = JsonConvert.DeserializeObject<TodoItem>(json);
        
        return View(data);    // pass the data the your view
    }
    
    // razor view
    @model WebApplication1.Models.TodoItem    // define model for view
    @{
        Layout = "_Layout.cshtml";
    }
    @foreach (var task in Model.Tasks)
    {
        <div>Id: @task.Id, Name: @task.Name</div>
    }
