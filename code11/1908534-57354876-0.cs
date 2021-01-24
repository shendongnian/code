        [Authorize]
        [HttpPost]
        public ActionResult Convalida([Bind(Include = "Id_Dettaglio,Id_Foglio,CommessaId,Aiutanti,Automezzo,Convalidato,DataConvalida")] FoglioGiornalieroDettaglioViewModel item)
        {
            var dip = SessionHelper.Dipendente;
            FoglioGiornalieroManager fm = new FoglioGiornalieroManager();
            int save =fm.Convalida(dip.matric, item);
            if(save>0)
            {
                ViewBag.message = "Convalida effettuata correttamente";
            }
            else {
                ViewBag.message = "C'è stato un problema con la convalida";
            }
            return RedirectToAction("Edit", "FoglioGiornaliero", new {id_foglio = item.Id_Foglio});
        }
