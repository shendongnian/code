    [HttpPost]
    public ActionResult Prueba(FormCollection collection)
            {
                for (var i = 0; i < 5; i++)
                {
                    var txtCantidadTabla = collection["txtCantidadTabla[" + i + "]"];
                    var txtCostoTabla = collection["txtCostoTabla[" + i + "]"];
                    var txtPrecioTabla = collection["txtPrecioTabla[" + i + "]"];
                    // handle your logic here
                }
                return View();
            }
