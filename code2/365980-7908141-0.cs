			var gridView = new GridView { AllowsColumnReorder = true, ColumnHeaderToolTip = "Employee Information" };
			// column 1
			var col1 = new GridViewColumn { DisplayMemberBinding = new Binding("FirstName"), Header="First Name", Width=100 };
			gridView.Columns.Add(col1);
			// column 2 
			var col2 = new GridViewColumn { Header="Last Name", Width=100 };
			var fef2 = new FrameworkElementFactory(typeof(TextBox));
			fef2.SetValue(TextBox.HeightProperty, 25d);
			fef2.SetBinding(TextBox.TextProperty, new Binding("LastName"));
			col2.CellTemplate = new DataTemplate { VisualTree = fef2 };
			gridView.Columns.Add(col2);
			// column 3
			var col3 = new GridViewColumn { Header = "ID", Width = 75 };
			var fef3 = new FrameworkElementFactory(typeof(TextBox));
			fef3.SetValue(TextBox.HeightProperty, 25d);
			fef3.SetBinding(TextBox.TextProperty, new Binding("EmployeeNumber"));
			col3.CellTemplate = new DataTemplate { VisualTree = fef3 };
			gridView.Columns.Add(col3);
