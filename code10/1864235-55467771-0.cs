csharp
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Polly;
using Polly.Timeout;
public class Program
{ 
	public static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
		try {
            timeoutPolicy().GetAwaiter().GetResult();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
		
        stopwatch.Stop();
        Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
    }
	
	static async Task timeoutPolicy()
    {
        var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(1); // setup the timeout limit to be 1 sec
        HttpResponseMessage response = await timeoutPolicy.ExecuteAsync((ct) => LongOperation(ct), CancellationToken.None);
    }
    static async Task<HttpResponseMessage> LongOperation(CancellationToken token)
    {
        await Task.Delay(5000, token);
        return new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.BadRequest
        };
    }
} 
