    public static async Task<int> AddNumbers(int num1, int num2)
    {
        try
        {
            using(var client = new HttpClient())
            {
                return Int32.Parse(await client.GetStringAsync($"http://<sitename>:12345/api/add?num1={num1}&num2={num2}"));
            }
        }
        catch (Exception e)
        {
            //Do something with the exception
        }
    
        return 0;
    }
