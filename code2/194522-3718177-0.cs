			var grouped = items.GroupBy(i => i.Name);
			grouped.ForEach(x => {
				x.ForEach(e => {
					// results handled here
					// assumes that all objects inheriting "Item" implement IItem, which contracts "Add" method.
					e.GetType().GetInterfaces().First(i => i.Name == "IItem").GetMethod("Add").Invoke(e, new object[] { e });
				});
			});
