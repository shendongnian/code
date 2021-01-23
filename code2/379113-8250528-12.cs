    interface IXY : IX, IY { }
    //       This IE could be var, but just strongly typing it for example
    foreach (IEnumerable<IXY> o in objects.OfType(IXY)
                                          .Cast<IXY>())
    {
      o.DoStuff();
      o.DoX();
      o.DoY();
    }
