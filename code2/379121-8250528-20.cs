    interface IXY : IX, IY { }
    //       This IXY could be var, but just strongly typing it for example
    foreach (IXY o in objects.OfType(IXY)
                             .Cast<IXY>())
    {
      o.DoStuff();
      o.DoX();
      o.DoY();
    }
