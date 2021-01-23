    double _width = 2; //two inches
    double _height = 2; //two inches
    
     dynamic item = device.Items[1]; // get the first item
                       
     int dpi = 150;
    
                        item.Properties["6146"].Value = 2; //greyscale
                        item.Properties["6147"].Value = dpi;
                        item.Properties["6148"].Value = dpi;
                        item.Properties["6151"].Value = (int)(dpi * _width);
                        item.Properties["6152"].Value = (int)(dpi * _height);
