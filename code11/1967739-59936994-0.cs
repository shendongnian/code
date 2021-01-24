public void LoadProcedure(int n, Action<int> inAction)
{
	// LoadingDisplay loadingDisplay=new LoadingDisplay(n);
	for (int i = 0; i <= n; i++)
	{
		if (i == n / 4)
		{
			inAction(i);
            break;
		}
	}
}
This will run your action, exit the loop, and return to the invoking method.
