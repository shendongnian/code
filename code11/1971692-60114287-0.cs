      [HttpPost]
    public async Task<ActionResult> PartialTabelaEcp(string userDate)
            {
                 var numerMiesiaca = 1;
                 var numerRoku = 1;
                 var dbExists = _ecpContext.Karta.FirstOrDefaultAsync(f => f.DzMiesiaca == 1 && f.Miesiac == 
                                               numerMiesiaca && f.Rok == numerRoku && f.Login == userName);
                if (dbExists == null)
                {
                    List<Karta_Model> objKartaModel = new List<Karta_Model>();
    
                    for (int i = 1; i <= liczbaDni; i++)
                    {
                        DateTime thisDate = new DateTime(numerRoku, numerMiesiaca, i);
    
    
                        var day = culture.DateTimeFormat.GetDayName(thisDate.DayOfWeek);
                        var model = new Karta_Model()
                        {
                            DzMiesiaca = i,
                            DzTygodnia = day,
                            Rozpoczecie = "00:00"
                        };
    
                        objKartaModel.Add(model);
    
                    }
    
    
                    _ecpContext.Karta.AddRangeAsync(objKartaModel);
                    _ecpContext.SaveChangesAsync();
                }
    
            }
     return PartialView("_TabelaEwidencja" );
