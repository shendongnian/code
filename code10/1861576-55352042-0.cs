csharp
public static void RegisterKeyHandler(Action<ConsoleKeyInfo> handler)
{
	Task.Run(() =>
	{
		while (true)
		{
			var key = Console.ReadKey();
			handler(key);
		}
	});
}
This only receives keys while the console window is focused.
