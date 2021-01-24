           ...
          [1]          var cardsData = DbContext.MasterpassBulkLoad.Take(15).ToList();
          [1]          foreach (var cardDetails in cardsData)
          [1]          {
          [1]              Console.WriteLine(cardDetails.Msisdn);
          [1]              Console.WriteLine(cardDetails.Status == null);
          [1]              HttpResponseMessage res = await cons.PostAsJsonAsync("api/Cardmanagement/CardLoad", cardDetails);
          [2]              cardDetails.Status = (int)res.StatusCode;
          [2]              Console.WriteLine("before save");
          [2]              DbContext.SaveChanges();
