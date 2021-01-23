     public void DrawLine(VertexPositionColor[] Vertices)
        {           
            Game.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            Vector2 center;
            center.X = Game.GraphicsDevice.Viewport.Width * 0.5f;
            center.Y = Game.GraphicsDevice.Viewport.Height * 0.5f;
         
            Matrix View = Matrix.CreateLookAt( new Vector3( center, 0 ), new Vector3( center, 1 ), new Vector3( 0, -1, 0 ) );
            Matrix Projection = Matrix.CreateOrthographic( center.X * 2, center.Y * 2, -0.5f, 1 );
            Effect EffectLines = Game.Content.Load<Effect>( "lines" );
            EffectLines.CurrentTechnique = EffectLines.Techniques["Lines"];
            EffectLines.Parameters["xViewProjection"].SetValue( View * Projection );
            EffectLines.Parameters["xWorld"].SetValue( Matrix.Identity );
            foreach ( EffectPass pass in EffectLines.CurrentTechnique.Passes )
            {
                pass.Apply( );
                Game.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>
                    ( PrimitiveType.LineList, Vertices, 0, Vertices.Length/2 );
            }            
        }
