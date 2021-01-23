    @{var grid = new WebGrid(source: Model);}
    <div>
       <h2>Multi User Login</h2>
       @using (Html.BeginForm())
       {
          @grid.GetHtml(columns: grid.Columns(
             grid.Column("CompanyName"),
             grid.Column("Address"),
             grid.Column(format: (item) => Html.ActionLink("Click me", "MyAction", new { Id = item.idAddress}))
          ))
       }
    </div>
