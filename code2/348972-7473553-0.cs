  bool OwnMyImage;
  Image MyImage;
  void SetImage(Image NewImage, bool TakeOwnership)
  {
    IDisposable oldDisposable; // Could reuse one variable for multiple IDisposables
    if (OwnMyImage)
    {
      oldDisposable = Threading.Interlocked.Exchange(MyImage, null);
      if (oldDisposable != null)
        oldDisposable.Dispose();
    }
    OwmMyImage = TakeOwnership;
    MyImage = NewImage;
  }
