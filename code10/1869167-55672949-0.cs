var selectList = AspFor.Model as IEnumerable<SelectListItem>;
if (selectList == null) {
   var msg = "CheckboxList tag helper attribute 'asp-for' must of type " +
      "IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>!";
   throw new Exception(msg);
}
