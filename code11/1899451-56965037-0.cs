public BitmapImage Image { get; set; }
    BitmapImage red = new BitmapImage(new Uri(@"C:\ProjetVisual\SmartieWpf\SmartieWpf\Img\bullet_red.png"));
    BitmapImage green = new BitmapImage(new Uri(@"C:\ProjetVisual\SmartieWpf\SmartieWpf\Img\bullet_green.png"));
    if(item.Visibility == Visibility.Collapsed)
    {
        item.Image = green;
    }
    else
    {
        item.Image = red;
    }
    
    DataGridTemplateColumn colDiff = new DataGridTemplateColumn
                    {
                        Header = "Etat"
                    };
    double imgSize = 20.0;
    DataTemplate DttEtat = new DataTemplate();
    FrameworkElementFactory image = new FrameworkElementFactory(typeof(Image));
    image.SetValue(Image.HeightProperty, imgSize);
    image.SetValue(Image.WidthProperty, imgSize);
    image.SetBinding(Image.SourceProperty, new Binding("Image"));
    image.SetValue(Image.SourceProperty, green);
    DttEtat.VisualTree = image;
    colDiff.CellTemplate = DttEtat;
    dgBordereaux.Columns.Add(colDiff);
