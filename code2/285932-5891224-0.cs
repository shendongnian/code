for (int i = 1; i <= 5; i++) {
	Console.WriteLine("On the " + i + " day of christmast my true love gave to me");
	switch (i) {
	case 5:
		Console.WriteLine("5 Gold Rings");
		goto case 4;
	case 4:
		Console.WriteLine("4 Colly Birds");
		goto case 3;
	case 3:
		Console.WriteLine("3 French Hens");
		goto case 2;
	case 2:
		Console.WriteLine("2 Turtle Doves");
		goto case 1;
	case 1:
		Console.WriteLine("And a Partridge in a Pear Tree");
		break;
	}
	Console.WriteLine("-");
}
</pre>
