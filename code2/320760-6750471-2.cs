		foreach (TElement current in source)
		{
			if (array == null)
			{
				array = new TElement[4];
			}
			else
			{
				if (array.Length == num)
				{
                    // Doubling happens *here*
					TElement[] array2 = new TElement[checked(num * 2)];
					Array.Copy(array, 0, array2, 0, num);
					array = array2;
				}
			}
			array[num] = current;
			num++;
		}
