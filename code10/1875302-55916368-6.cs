    public ActionResult Index()
    {
        YourModel model = new YourModel();
    
        return View(model );
    }
    
    @model your modal
    
     @(Html.Kendo().AutoComplete()
            .Name("yourName") //The name of the AutoComplete is mandatory. It specifies the "id" attribute of the widget.
            .DataTextField("nameYourControl") //Specify which property of the Product to be used by the AutoComplete.
            .BindTo(Model) //Pass the list of Products to the AutoComplete.
            .Filter("contains") //Define the type of the filter, which AutoComplete will use.
        )
