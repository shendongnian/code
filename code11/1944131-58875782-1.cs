	Transactions dataset = new Transactions();
	dataset.Orders.AddOrderRow("1");
	dataset.Orders.AddOrderRow("2");
	dataset.Lines.AddLineRow(dataset.Orders[0], 1);
	dataset.Lines.AddLineRow(dataset.Orders[0], 2);
	dataset.Lines.AddLineRow(dataset.Orders[0], 3);
	dataset.Lines.AddLineRow(dataset.Orders[1], 1);
	dataset.Lines.AddLineRow(dataset.Orders[1], 2);
	dataset.Lines.AddLineRow(dataset.Orders[1], 3);
	Console.WriteLine($"Total Number of Lines before delete is {dataset.Lines.Count}"); // Prints 6
	//dataset.Orders.Rows.Clear();
	dataset.Orders.RemoveAll();
	Console.WriteLine($"Total Number of Lines after delete is {dataset.Lines.Count}"); // Prints 0
