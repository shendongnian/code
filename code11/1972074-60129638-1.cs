    List<Karta_Model> objNextKartaModel = new List<Karta_Model>();
    
    for (int i = 0; i < liczbaDni; i++)
    {
         var modelNext = new Karta_Model()
         {
             Login = userName,
             Rok = numerRoku,
             Miesiac = numerMiesiaca,
             DzMiesiaca = modelKarta.Model1[i].DzMiesiaca.Value,
             DzTygodnia = modelKarta.Model1[i].DzTygodnia,
             Rozpoczecie = modelKarta.Model1[i].Rozpoczecie
             ....
        };
    
        objNextKartaModel.Add(modelNext);
        
        //Add logic to delete the existing data
        foreach(var model in _ecpContext.Karta)
        {
           _ecpContext.Karta.Remove(model);
        } 
        await _ecpContext.Karta.AddRangeAsync(objNextKartaModel);
        await _ecpContext.SaveChangesAsync();//One SaveChanges call is enough to update the database
    }
