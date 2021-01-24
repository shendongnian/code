    using (var cons = new HttpClient())
    {
        cons.BaseAddress = new Uri("http://cbsswfint01:53303/");
        cons.DefaultRequestHeaders.Accept.Clear();
        cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        try
        {
           using(var context = new DbContext())
           {
               var cardsData = await context.MasterpassBulkLoad.Take(15).ToListAsync();
               foreach (var cardDetails in cardsData)
               {
                    Console.WriteLine(cardDetails.Msisdn);
                    Console.WriteLine(cardDetails.Status == null);
                    HttpResponseMessage res = cons.PostAsJson("api/Cardmanagement/CardLoad", cardDetails);
                            cardDetails.Status = (int)res.StatusCode;
               }
               Console.WriteLine("before save");
               await context.SaveChangesAsync();
               Console.WriteLine("After Save");
           }
       }
       catch (Exception ex)
       {
               Console.WriteLine(ex.InnerException.Message);
               _logger.LogError(ex.InnerException.StackTrace);
       }
    }
