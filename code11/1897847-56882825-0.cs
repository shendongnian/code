 static void Main(string[] args)
{
	Console.WriteLine($"Type your link here: ");
	string url = Console.ReadLine();	
	url = url.Substring(0, url.Length - 3);
	GoToSite(url);
	Console.ReadKey();
}
public static void GoToSite(string url)
{
	  string chromeArgs = $"--new-window {url}";
      Process.Start("chrome.exe", chromeArgs);	
}
