		private void LoadItems(object value, Type type)
		{
			if (type.IsClass)
			{
				foreach (object item in (object[])_value)
				{
					Items.Add(item);
					if (item is INotifyPropertyChanged npc)
						npc.PropertyChanged += OnItemPropertyChanged;
				}
				return;
			}
			if (type == typeof(bool))
			{
				LoadItems((bool[])value);
			}
			else if (type == typeof(byte))
			{
				LoadItems((byte[])value);
			}
			else if (type == typeof(char))
			{
				LoadItems((char[])value);
			}
			else if (type == typeof(DateTime))
			{
				LoadItems((DateTime[])value);
			}
			else if (type == typeof(decimal))
			{
				LoadItems((decimal[])value);
			}
			else if (type == typeof(double))
			{
				LoadItems((double[])value);
			}
			else if (type == typeof(float))
			{
				LoadItems((float[])value);
			}
			else if (type == typeof(int))
			{
				LoadItems((int[])value);
			}
			else if (type == typeof(long))
			{
				LoadItems((long[])value);
			}
			else if (type == typeof(sbyte))
			{
				LoadItems((sbyte[])value);
			}
			else if (type == typeof(short))
			{
				LoadItems((short[])value);
			}
			else if (type == typeof(string))
			{
				LoadItems((string[])value);
			}
			else if (type == typeof(TimeSpan))
			{
				LoadItems((TimeSpan[])value);
			}
			else if (type == typeof(uint))
			{
				LoadItems((uint[])value);
			}
		}
		private void LoadItems<T>(T[] array)
		{
			foreach (T item in array)
			{
				Items.Add(item);
			}
		}
