C#
public void Check()
{
	var sw = new System.Diagnostics.Stopwatch();
	
	sw.Start();
	for (int i = 0; i < 99; i++)
	{
		if (sw.ElapsedMilliseconds > 4000)
		{
			break;
		}
		
		if (ListOne.Test.Contains(UserInput()))
		{
			Console.WriteLine("Correct!");
			points++;
			if (points == ListOne.Test.Capacity)
			{
				break;
			}
			else
			{
				continue;
			}
		}
		else
		{
			Console.WriteLine("Wrong!");
		}
	}
	Console.WriteLine("Stopped\n");
}
(note, you could move or add a check to after the question depending on your requirements. You could also add a flag in the for loop so you could check afterwards if all the questions were answered before it exited)
A more elegant solution might be to use a `Task` with an absolute timeout:-
C#
public void Check()
{
	var task = new Task(() =>
	{
		for (int i = 0; i < 99; i++)
		{
			if (ListOne.Test.Contains(UserInput()))
			{
				Console.WriteLine("Correct!");
				points++;
				if (points == ListOne.Test.Capacity)
				{
					break;
				}
				else
				{
					continue;
				}
			}
			else
			{
				Console.WriteLine("Wrong!");
			}
		}
	}
	// this will block for 4 seconds; if the task hasn't completed by then,
    // the task function will exit, and it will run the code in the if-block below
	if (!task.Wait(4000))
	{
		Console.WriteLine("Max time reached");
	}
}
