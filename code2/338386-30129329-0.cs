    void RotateFlipRect(CRect & pRect, int pNewContainerWidth, int pNewContainerHeight, Gdiplus::RotateFlipType pCorrection)
    {
      CRect lTemp = pRect;
    
      switch (pCorrection)
      {
        case    RotateNoneFlipNone: // = Rotate180FlipXY
          break;
        case         Rotate90FlipNone:  // = Rotate270FlipXY
          pRect.left = lTemp.top;
          pRect.top = pNewContainerHeight - lTemp.right;
          pRect.right = lTemp.bottom;
          pRect.bottom = pNewContainerHeight - lTemp.left;
          break;
        case         Rotate180FlipNone: // = RotateNoneFlipXY
          pRect.left = pNewContainerWidth - lTemp.right;
          pRect.top = pNewContainerHeight - lTemp.bottom;
          pRect.right = pNewContainerWidth - lTemp.left;
          pRect.bottom = pNewContainerHeight - lTemp.top;
          break;
        case         Rotate270FlipNone: // = Rotate90FlipXY
          pRect.left = pNewContainerWidth - lTemp.bottom;
          pRect.top = lTemp.left;
          pRect.right = pNewContainerWidth - lTemp.top;
          pRect.bottom = lTemp.right;
          break;
        case         RotateNoneFlipX: // = Rotate180FlipY
          pRect.left = pNewContainerWidth - lTemp.right;
          pRect.top = lTemp.top;
          pRect.right = pNewContainerWidth - lTemp.left;
          pRect.bottom = lTemp.bottom;
          break;
        case         Rotate90FlipX: // = Rotate270FlipY
          pRect.left = pNewContainerWidth - lTemp.bottom;
          pRect.top = pNewContainerHeight - lTemp.right;
          pRect.right = pNewContainerWidth - lTemp.top;
          pRect.bottom = pNewContainerHeight - lTemp.left;
          break;
        case         Rotate180FlipX: // = RotateNoneFlipY
          pRect.left = lTemp.left;
          pRect.top = pNewContainerHeight - lTemp.bottom;
          pRect.right = lTemp.right;
          pRect.bottom = pNewContainerHeight - lTemp.top;
          break;
        case         Rotate270FlipX:  // = Rotate90FlipY
          pRect.left = lTemp.top;
          pRect.top = lTemp.left;
          pRect.right = lTemp.bottom;
          pRect.bottom = lTemp.right;
          break;
        default:
          // ?!??!
          break;
      }
    }
