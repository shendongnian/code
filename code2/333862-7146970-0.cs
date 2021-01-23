    [HttpPost, ActionName("ToonStudenten")]
            public ActionResult VeranderStudentenKlas(string[] deleteInputsKlas1, string[] deleteInputsKlas2, string id, int id1, string geselecteerdeKlasUitDropDown, string searchpara1, string searchpara2)// id = klasnaam1, id1 = opdrachtID, id2 = klasgroep2)
            {
    
                if (deleteInputsKlas2 == null && deleteInputsKlas1 == null)
                {
    
                        ModelState.AddModelError("", "Er werden geen Studenten geselecteerd");
                        return RedirectToAction("ToonStudenten", "Docent", new { id = id, id1 = id1, geselecteerdeKlasUitDropDown = geselecteerdeKlasUitDropDown, searchpara1 = searchpara1, searchpara2 = searchpara2 });
                }
    
                    if (deleteInputsKlas1 != null)
                        foreach (var item in deleteInputsKlas1)
                        {
                            try
                            {
                                if (geselecteerdeKlasUitDropDown == "")
                                    StudentRepo.VeranderKlas(item, null);
                                else
                                    StudentRepo.VeranderKlas(item, geselecteerdeKlasUitDropDown);
                            }
                            catch (Exception er)
                            {
                                ModelState.AddModelError("", "Fout bij Student met ID " + item + " : " + er.Message);
                                return View("error");
                            }
                        }
    
                    if (deleteInputsKlas2 != null)
                        foreach (var item in deleteInputsKlas2)
                        {
                            try
                            {
                                StudentRepo.VeranderKlas(item, id);
                            }
                            catch (Exception er)
                            {
                                ModelState.AddModelError("", "Failed on ID " + item + " : " + er.Message);
                                return View("error");
                            }
                        }
    
                    StudentRepo.SaveChanges();
                    return RedirectToAction("ToonStudenten", "Docent", new { id = id, id1 = id1, geselecteerdeKlasUitDropDown = geselecteerdeKlasUitDropDown, searchpara1 = searchpara1, searchpara2 = searchpara2 });
           
