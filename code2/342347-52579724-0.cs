        /// <summary>
        /// Line up the textures in list horizontally. Warning: All textures MUST BE one height and in strong order
        /// </summary>
        /// <param name="device">D3D device</param>
        /// <param name="textures">List of textures</param>
        /// <returns>Combined texture</returns>
        public static Texture LineUpTexturesHorizontally ( Device device, List < Texture > textures )
        {
            int dstWidth = textures.Select ( texture => texture.GetSurfaceLevel ( 0 ) ).Select ( surface => surface.Description.Width ).Sum ( );
            int dstHeight = textures [ 0 ].GetSurfaceLevel ( 0 ).Description.Height;
            Texture dstTexture = CreateTexture ( device, dstWidth, dstHeight, Color.Orange, TexMipLevels, true );
            Surface dstSurface = dstTexture.GetSurfaceLevel ( 0 );
            Point insPoint = new Point ( 0, 0 );
            for ( int i = 0; i < textures.Count; i++ )
            {
                PaletteEntry [ ] pal; // = new PaletteEntry[ 256 ];
                Texture srcTexture = textures [ i ];
                Surface srcSurface = srcTexture.GetSurfaceLevel ( 0 );
                int srcWidth = srcSurface.Description.Width;
                int srcHeight = srcSurface.Description.Height;
                Rectangle srcRectangle = new Rectangle ( 0, 0, srcWidth, srcHeight );
                Rectangle dstRectangle = new Rectangle ( insPoint, new Size ( srcWidth, srcHeight ) );
                SurfaceLoader.FromSurface ( dstSurface, out pal, dstRectangle, srcSurface, out pal, srcRectangle, Filter.None, 0 );
                insPoint.X += srcWidth;
            }
            return dstTexture;
        }
