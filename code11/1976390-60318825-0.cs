   	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Text;
	namespace Test
	{
		public class MyClassSelectable
		{
			public bool Selected { get; set; }
			public string Name { get; set; } = "";
		}
		public class Class1
		{
			public ObservableCollection<MyClassSelectable> myClassesSelectable = new ObservableCollection<MyClassSelectable>();
			public Class1()
			{
				myClassesSelectable.Add(new MyClassSelectable { Selected = true, Name = "Item 1" });
				myClassesSelectable.Add(new MyClassSelectable { Selected = true, Name = "Item 2" });
				myClassesSelectable.Add(new MyClassSelectable { Selected = false, Name = "Item 3" });
				myClassesSelectable.Add(new MyClassSelectable { Selected = false, Name = "Item 4" });
				IEnumerable<MyClassSelectable> myCollection = myClassesSelectable
								// group by the Selected property
								.GroupBy(mcs => mcs.Selected)
								// order (=> true first, false second)
								.OrderByDescending(g => g.Key)
								// return the first OR an empty collection if there are no items
								.FirstOrDefault()
								.ToList();
			}
		}
	}
