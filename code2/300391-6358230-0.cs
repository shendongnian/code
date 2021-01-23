    Html.Grid(Model.Customers)
              .Columns(c =>
                {
                    c.For(x => Html.ActionLink(x.Name, MVC.Partner.Edit(x.ID), new { @class = "ILPartnerEdit" }))
                        .Named(LanguageResources.Name);
    ...
