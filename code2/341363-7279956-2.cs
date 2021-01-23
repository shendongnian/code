    @model Experiments.AspNetMvc3NewFeatures.Razor.Models.ContentPage
    @{
        View.Title = Model.Title;
    } 
     
    <h2>About</h2>
    <p>
         @Model.Description
    </p>
