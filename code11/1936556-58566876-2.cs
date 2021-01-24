            PeopleListView.ItemTemplate = new DataTemplate(() => 
            {
                ViewCell vc = new ViewCell();
                Grid vcGrid = new Grid();
                vcGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                vcGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                vcGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                vcGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                var gridImg = new Image();
                gridImg.SetBinding(Image.SourceProperty, "EmbeddedPhoto");
                gridImg.HeightRequest = 80;
                gridImg.WidthRequest = 80;
                gridImg.Aspect = Aspect.AspectFill;
                vcGrid.Children.Add(gridImg, 0, 0);
                Grid.SetRowSpan(gridImg, 2);
                var nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                nameLabel.FontAttributes = FontAttributes.Bold;
                vcGrid.Children.Add(nameLabel, 1, 0);
                var clientsLabel = new Label();
                clientsLabel.SetBinding(Label.TextProperty, "List");
                clientsLabel.VerticalOptions = new LayoutOptions(LayoutAlignment.End, false);
                vcGrid.Children.Add(nameLabel, 1, 1);
                vc.View = vcGrid;
                return vc;
            });
