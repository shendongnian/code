	using System;
	public class Program
	{
		public static void Main()
		{
			// array of numbers
			int[] numbers = { 9, 5, 4, 15, 3, 8, 11, 2 };
            // declare a boolean.
			bool done;
			do
			{
                // when nothing happens, you're done.
				done = true;
                // create a for-loop to iterate all item-1 (except the last)
				for(int position=0;position<numbers.Length-1;position++)
				{
                    // compare the values in the array
					if (numbers[position] > numbers[position+1])
					{
                        // swap the values
						int temp = numbers[position];
						numbers[position] = numbers[position + 1];
						numbers[position + 1] = temp;
                        // if something was swapped, you're not ready.
						done = false;
					}
				}
                // loop until done is set.
			} while (!done);
			Console.WriteLine(string.Join(",", numbers));
		}
	}
