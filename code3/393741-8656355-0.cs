    private static ArrayList _listOfCars = new ArrayList { "Audi", "BMW", "Ford" };
    
    protected override Page_Load ...
    {
       DropDownList1.DataSource = _listOfCars;
       DropDownList1.DataBind();
    }
