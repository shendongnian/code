    bool IsRegionTransparent(Texture2D texture, Rectangle r)
    {
        int size = r.Width * r.Height;
        Color[] buffer = new Color[size];
        texture.GetData(0, r, buffer, 0, size);
        return buffer.All(c => c == Color.Transparent);
    }
