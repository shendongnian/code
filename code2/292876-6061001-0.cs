    // Compute existing aspect ratio
    double aspectRatio = (double)image.Width / image.Height;
    // Clip the desired values to the maximums
    desiredHeight = Math.Min(desiredHeight, MaxHeight);
    desiredWidth = Math.Min(desiredWidth, MaxWidth);
    // This is the aspect ratio if you used the desired values.
    double newAspect = (double)desiredWidth / desiredHeight;
    if (newAspect > aspectRatio)
    {
        // The new aspect ratio would make the image too tall.
        // Need to adjust the height.
        desiredHeight = (int)(desiredWidth / aspectRatio);
    }
    else if (newAspect < aspectRatio)
    {
        // The new aspect ratio would make the image too wide.
        // Need to adjust the width.
        desiredWidth = (int)(desiredHeight * aspectRatio);
    }
    // You can now resize the image using desiredWidth and desiredHeight
