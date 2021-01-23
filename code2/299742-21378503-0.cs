        MemoryStream stream = new MemoryStream(data);
        Image image = Image.FromStream(stream);
        foreach (var prop in image.PropertyItems) {
            if ((prop.Id == 0x0112 || prop.Id == 5029 || prop.Id == 274)) {
                var value = (int)prop.Value[0];
                if (value == 6) {
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                } else if (value == 8) {
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                } else if (value == 3) {
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                } 
            }
        }
