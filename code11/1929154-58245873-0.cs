var usernames = new List<string>(){ "BUL", "GVL", "UDF", "RFT", "WDR" };
int[] passwords = { 100, 200, 300, 400, 500 };
var user = Policy
    .HandleResult<String>(r => !usernames.Contains(r))
    .RetryForever((r)=> Console.WriteLine($"Username is incorrect, Try again"))
    .Execute(() => {
        Console.WriteLine("Enter Username:");
        return Console.ReadLine();
    });
var expectedPassword = passwords[usernames.IndexOf(user)];
var maxRetries = 5;
Policy
    .HandleResult<int>(r => r != expectedPassword)
    .Retry(maxRetries, (r, i) => Console.WriteLine($"Password is incorrect. Retries left: {maxRetries - i + 1}"))
    .Execute(() => {
        Console.WriteLine("Enter Password:");
        // should here also be a retry? try do that with Polly :)
        int.TryParse(Console.ReadLine(),  out var password);
        return password;
    });
