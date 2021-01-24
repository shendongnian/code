public static void Main()
{
	var start = 3; //StartTextBox.Text
	var end = 10; //EndTextBox.Text
	var symbol = "@"; //SymbolTextBox.Text
	for (var i = start; i < end; i++)
	{
		var toPrint = string.Empty;
		for (var j = 0; j < i; j++) toPrint += symbol;
		Console.WriteLine(toPrint); //LabelX.Text = toPrint;
	}
	Console.ReadLine();
}
You can see in the above code that if you change the value of `start` to any number, the value gets printed properly.
