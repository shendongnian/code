    for (int k = 0; k < pl2.Length; k++)
    {
         p.countWithStepActivation(ref tmpNewEntry);
         // Console.WriteLine("answer = {0} | t = {1} | tmpNewEntry = {2}", p.answer, p.theta, tmpNewEntry);
         if(pl2[k] != null)
         {
             pl2[k].changeEntry(k, tmpNewEntry);
         }
    }
