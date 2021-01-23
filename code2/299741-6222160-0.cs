    foreach (PropertyItem p in properties) {
          if (p.Id == 274) {
                Orientation = (int)p.Value[0];
             if (Orientation == 6)
                oldImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
             if (Orientation == 8)
                oldImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
          break;
          }
    }
