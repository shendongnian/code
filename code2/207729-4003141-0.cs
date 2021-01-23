		using System;
		using System.Collections;
		using System.Collections.Generic;
		namespace CSharpSampleApplication.Data.CoreObjects
		{
			[Serializable]
			public class CalcItem
			{
				public CalcItem()
				{
					_additional = new List<double>();
				}
				private readonly List<double> _additional;
				public bool ContainsKey(int id)
				{
					return _additional.Count - 1 >= id;
				}
				public void Add(int id, double value)
				{
					if(ContainsKey(id))
						_additional[id] = value;
					else
					{
						while (!ContainsKey(id))
						{
							_additional.Add(0);
						}
						_additional[id] = value;
					}
				}
				public DateTime Date { get; set; }
				public object this[int id]
				{
					get
					{
						return _additional[id];
					}
				}
			}
			
		}
