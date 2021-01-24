    public static class ListExtensions
    {
        public static int InstanceCount(this List<double> list, Predicate<double> predicate)
        {
			int instanceCount = 0;
			bool instanceOccurring = false;
			
			foreach (var item in list)
			{
				if (predicate(item))
				{
					if (!instanceOccurring)
					{
						instanceCount++;
						instanceOccurring = true;
					}
				}
				else
				{
					instanceOccurring = false;
				}
			}
			
            return instanceCount;
        }
    }
