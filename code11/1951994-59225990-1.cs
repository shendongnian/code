using System;
			var numberVariable = 1;
			var text = "Hello World Times " + numberVariable;
			while (true)
			{
				Thread.Sleep(500);
				//writes the text into 0|0
				Console.WriteLine(text);
//LOOPBEGIN
//The cursor is now on 0|1
//Console.WriteLine advances the cursor to the next line so we need to set it to the previous line
//Ether by:
//Console.SetCursorPosition(0 /**Column 0**/, Console.CursorTop - 1);
//or by
				Console.CursorTop = Console.CursorTop - 1;
				Console.CursorLeft = 0;
//The cursor is now again on 0|0
				numberVariable = numberVariable + 1;
//increment the variable
				text = "Hello World Times " + numberVariable;
//ether set the text variable again or use a new variable
			}
https://docs.microsoft.com/de-de/dotnet/api/system.console.setcursorposition?view=netframework-4.8
