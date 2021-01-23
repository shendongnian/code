    Printer printer = new Printer("Printer Name");
    Bitmap image =new Bitmap ( Bitmap.FromFile("Icon.bmp"));
    printer.Image(image);
    printer.FullPaperCut();
    printer.PrintDocument();
