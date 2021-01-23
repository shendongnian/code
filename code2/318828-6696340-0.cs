    // Set up Plate Layer
    SharpMap.Layers.VectorLayer PlateLayer = new SharpMap.Layers.VectorLayer("PlateLayer");        
    PlateLayer.DataSource = new SharpMap.Data.Providers.ShapeFile(LayerPath + Region + "_plates.shp", false);
    Color c = Color.FromArgb(30, 100, 100, 100);
    Brush b = new SolidBrush(c);
    PlateLayer.Style.Fill = b;
    PlateLayer.Style.Outline = new Pen(Color.LightGray, 1);
    PlateLayer.Style.EnableOutline = true;
    MainMap.Layers.Add(PlateLayer);
