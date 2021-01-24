     @using (Html.BeginForm("Edit", "Firma", FormMethod.Post, new { id = "firma" }))
            {
                var id = Int32.Parse(Request["FirmaId"]);
                ProjekthafenEntities phentitis = new ProjekthafenEntities();
    
                @Html.Partial("~/Views/Firma/Edit.cshtml", phentitis.Firma.Find(id));
    
            }
