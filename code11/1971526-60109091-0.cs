[HttpGet]
public JsonResult ProcessEditPesoArticolo(int idArticolo, string pesoArticolo)
{           
  // replace DE-de with your own culture
  var pesoArticoloDouble = double.Parse(pesoArticolo, new CultureInfo("DE-de"));
}
