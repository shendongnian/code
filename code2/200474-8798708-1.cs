    Texture texture;
    Rectangle textureSize;
    private void InitiateTexture()
    {
        texture = new Texture(device, new Bitmap("CAR.jpg"), Usage.None, Pool.Managed);
        using (Surface surface = texture.GetSurfaceLevel(0))
        {
            SurfaceDescription surfaceDescription = surface.Description;
            textureSize = new Rectangle(0, 0, 
                              surfaceDescription.Width, 
                              surfaceDescription.Height);
        }
    }
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        device.Clear(ClearFlags.Target, Color.DarkSlateBlue, 1.0f, 0);
        device.BeginScene();
        Sprite sprite = new Sprite(device);
        sprite.Begin(SpriteFlags.None);
        sprite.Draw(texture, textureSize, 
        new Vector3(0, 0, 0), 
        new Vector3(0, 0, 0), Color.White);
        sprite.End();
        device.EndScene();
        device.Present();
    }
