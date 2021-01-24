    public void Test(string content)
    {
      using (var client = new HttpClient())
      {
         try
         {
            var res = client.PostAsync("http://localhost:4000/api/activation/activate",
                    new StringContent(content, Encoding.UTF8, "application/json");
           res.Result.EnsureSuccessStatusCode();
           Console.WriteLine("Response " + res.Result.Content.ReadAsStringAsync().Result +
           Environment.NewLine);
         }
         catch (Exception e)
         {
           Console.WriteLine(e.ToString());
         }
       }
     }
