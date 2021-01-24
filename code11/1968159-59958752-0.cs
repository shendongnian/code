c#
var populatedProperties = Model.DetailsVMCourse.GetType().GetProperties().Where(prop => prop.GetValue(Model.DetailsVMCourse) != null);
foreach (var prop in populatedProperties){
   <h4>@prop.Name</h4>
   <p>
   @prop.GetValue(Model.DetailsVMCourse);
   </p>
}
