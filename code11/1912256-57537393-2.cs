    @model IEnumerable<CarSln.Models.PersonCar>
    @{
        ViewBag.Title = "Home Page";
    }
    <div class="row">
            @(Html.Grid(Model).Build(columns =>
                {
		           columns.Bound(x => x.PersonId);               
		           columns.Bound(x => x.PersonName);               
		           columns.Bound(x => x.CarId);               
		           columns.Bound(x => x.CarName);               
                 })
             )
    </div>
