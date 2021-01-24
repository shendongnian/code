    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        components?.Dispose();
        view2dProcess?.Dispose();
        view3dProcess?.Dispose();
        label?.Dispose();
      }
    
      base.Dispose(disposing);
    }
