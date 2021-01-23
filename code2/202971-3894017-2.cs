        protected override void LoadGraphicsContent(bool loadAllContent)
        {
            if (loadAllContent)
            {
                spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
                // TODO: Load any ResourceManagementMode.Automatic content
                t2dMap = content.Load<Texture2D>(@"content\textures\map_display");
                t2dColorKey = content.Load<Texture2D>(@"content\textures\map_colorkey");
            }
            // TODO: Load any ResourceManagementMode.Manual content
        }
