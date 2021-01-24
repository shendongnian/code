    public class Program {
    	public static async Task Main(string[] args) {
    		Console.WriteLine("Hello");
    		await CancelingTasks2();
    		Console.WriteLine("Exit");
    	}
    	
    	private static async Task CancelingTasks2() {
    		CancellationTokenSource cts = new CancellationTokenSource();
    		CancellationToken token = cts.Token;
    		
    		var t = print("printing for ever ...", token);
    		
    		await Task.Delay(2000);
    
    		cts.Cancel();
    
    		Console.WriteLine("canceled");
    		Console.WriteLine("task status  " + t.Status);
    		Console.WriteLine("token IsCancellationRequested  " + token.IsCancellationRequested);
    	}
    
    	private static async Task print(string txt, CancellationToken token) {
    		while (true) {
    			if (token.IsCancellationRequested)
    				throw new OperationCanceledException("cancelled on the token", token);
    			Console.WriteLine(txt); 
    			await Task.Delay(500);
    		}
    	}
    }
