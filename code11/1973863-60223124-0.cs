        public MagickImage ComebineBitmap(MagickImage Main, MagickImage Overlay)
        {
        MagickGeometry gm = new MagickGeometry();
        gm.Width = Main.Width;
        gm.Height = Main.Height;
        gm.IgnoreAspectRatio = true;
            Overlay.Density = Main.Density;
            Overlay.BitDepth(Main.BitDepth());
  
            Overlay.LiquidRescale(gm);
            Overlay.Transparent(MagickColors.Black);
          
            Main.Composite(Overlay, CompositeOperator.SrcOver);
        
           return Main;
        }
