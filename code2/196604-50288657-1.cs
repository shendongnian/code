    System.Drawing.Image imageToRotate = System.Drawing.Image.FromFile(imagePath);
    switch (rotationAngle.Value)
    {
    	case "90":
    		imageToRotate.RotateFlip(RotateFlipType.Rotate90FlipNone);
    		break;
    	case "180":
    		imageToRotate.RotateFlip(RotateFlipType.Rotate180FlipNone);
    		break;
    	case "270":
    		imageToRotate.RotateFlip(RotateFlipType.Rotate270FlipNone);
    		break;
    	default:
    		throw new Exception("Rotation angle not supported.");
    }
    imageToRotate.Save(imagePath, ImageFormat.Jpeg);
