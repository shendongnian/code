    class Program
	{
		static void Main(string[] args)
		{
			int angka = 0;
			Console.WriteLine("Masukkan Angka : ");
			while (angka < 1 || angka > 9)
			{
				int.TryParse(Console.ReadLine(), out angka);
				if (angka < 1 || angka > 9)
				{ Console.WriteLine("Please enter a number between 1 and 9"); }
			}
			System.Text.StringBuilder resultString = new System.Text.StringBuilder();
			for (int i = 1; i <= angka; i++)
			{
				resultString.Append(i.ToString());
				resultString.Append(i < angka ? "," : " hop!");
			}
			Console.WriteLine(resultString.ToString());
		}
	}
