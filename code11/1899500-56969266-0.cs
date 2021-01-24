_page.Console += async (sender, args) =>
{
	switch (args.Message.Type)
	{
		case ConsoleType.Error:
			try
			{
				var errorArgs = await Task.WhenAll(args.Message.Args.Select(arg => arg.ExecutionContext.EvaluateFunctionAsync("(arg) => arg instanceof Error ? arg.message : arg", arg)));
				_logger.LogError($"{args.Message.Text} args: [{string.Join<object>(", ", errorArgs)}]");
			}
			catch { }
			break;
		case ConsoleType.Warning:
			_logger.LogWarning(args.Message.Text);
			break;
		default:
			_logger.LogInformation(args.Message.Text);
			break;
	}
};
I got the idea from a comment from one of the puppeteer contributors [here](https://github.com/GoogleChrome/puppeteer/issues/3397#issuecomment-434970058) and ported it to pupeteer-sharp. 
>The way it's supposed to be done atm is like this:
