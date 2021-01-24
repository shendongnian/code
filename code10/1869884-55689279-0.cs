        public static async Task<DateTime>GetDateTime()
        {
            using (HttpClient client = new HttpClient())
            {
                // Omitted some code here for simplicity.
                try
                {
                    string result = await client.GetStringAsync(client.BaseAddress);
                    Date currentTime = JsonConvert.DeserializeObject<Date>(result);
                    return currentTime.Value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
Basically you can run Tasks ASYNC so when you call the function GetDateTime() you will start running the task without blocking the code below from execution like this:
Task<DateTime> getCurrentDate = MyClass.GetDateTime();
//Code here executes right away without waiting for the task to finish
In this case I started the task inside the constructor and awaited for it right before I was going to need the result like this:
DateTime result = await getCurrentDate;
Or you can start and await for the task to finish in the same line of code:
DateTime result = await MyClass.getCurrentDate();
With the method above it looks synchronously but you don't really take advantage of running one or more task while your other code executes.
