cs
async Task AskPermissionNew(object sender, EventArgs e)
{
	try
	{
		await Task.Run(async () =>
		{
			/* ... */
		});
	}
	except (Exception e)
	{
		Debug.Print(e.ToString());
	}
}
or
cs
void AskPermissionNew(object sender, EventArgs e)
{
	Task.Run(async () =>
	{
		try
		{
			var permissionStatus = await /* ... */
		}
		except (Exception e)
		{
			Debug.Print(e.ToString());
		}
	});
}
You will probably see the printout of the `Exception` you're currently silently ignoring.
