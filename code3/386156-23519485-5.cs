            //mijnZichtrekening.RekeningUittreksel += pietjePek.ToonUittreksel;
            //mijnZichtrekening.NegatiefSaldo += pietjePek.ToonNegatief;
            try
            {
                mijnZichtrekening.Storten(50m, mijnZichtrekening.RekeningUittreksel);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex);
            }
            try
            {
                mijnZichtrekening.Afhalen(100m, mijnZichtrekening.RekeningUittreksel, mijnZichtrekening.NegatiefSaldo);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex);
            }
  
        
    
    
 
