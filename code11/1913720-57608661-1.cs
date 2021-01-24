    Console.WriteLine(cardDetails.Status == null);
    Console.WriteLine(string.Format("Thread #{0} (before)", Thread.CurrentThread.ManagedThreadId));
    HttpResponseMessage res = await cons.PostAsJsonAsync("api/Cardmanagement/CardLoad", cardDetails);
    Console.WriteLine(string.Format("Thread #{0} (after)", Thread.CurrentThread.ManagedThreadId));
    cardDetails.Status = (int)res.StatusCode;
