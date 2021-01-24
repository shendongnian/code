c#
GridViewColumn gvc = new GridViewColumn();
DataTemplate dt = new DataTemplate();
FrameworkElementFactory fc = new FrameworkElementFactory(typeof(ItemsControl));
fc.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("ListOfSubObject"));
dt.VisualTree = fc;
gvc.CellTemplate = dt;
