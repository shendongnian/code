    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.IO;
    
    namespace Voodo.Utils {
    
        /// <summary>
        /// 
        /// </summary>
        public class TextureBaker {
    
            private readonly SpriteBatch _batch;
            private readonly RenderTarget2D _renderTarget;
            private readonly GraphicsDevice _graphicsDevice;
    
            /// <summary>
            /// 
            /// </summary>
            public Rectangle Bounds {
                get { return _renderTarget.Bounds; }
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="graphicsDevice"></param>
            /// <param name="size"></param>
            public TextureBaker(GraphicsDevice graphicsDevice, Vector2 size) {
    
                _graphicsDevice = graphicsDevice;
    
                _batch = new SpriteBatch(_graphicsDevice);
                _renderTarget = new RenderTarget2D(
                    _graphicsDevice, 
                    (int)size.X, 
                    (int)size.Y);
    
                _graphicsDevice.SetRenderTarget(_renderTarget);
    
                _graphicsDevice.Clear(Color.Transparent);
    
                _batch.Begin(
                    SpriteSortMode.Immediate, 
                    BlendState.AlphaBlend, 
                    SamplerState.LinearClamp,
                    DepthStencilState.Default, 
                    RasterizerState.CullNone);
            }
    
            #region Texture2D baking
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="texture"></param>
            public void BakeTexture(Texture2D texture) {
    
                _batch.Draw(
                    texture,
                    new Rectangle(0, 0, Bounds.Width, Bounds.Height), 
                    Color.White);
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="texture"></param>
            /// <param name="destination"></param>
            public void BakeTexture(Texture2D texture, Rectangle destination) {
    
                _batch.Draw(
                    texture,
                    destination,
                    Color.White);
            }        
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="texture"></param>
            /// <param name="destination"></param>
            /// <param name="source"></param>
            public void BakeTexture(Texture2D texture, Rectangle destination, Rectangle source) {
    
                _batch.Draw(
                    texture,
                    destination,
                    source,
                    Color.White);
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="texture"></param>
            /// <param name="sourceModification"></param>
            /// <param name="destination"></param>
            public void BakeTexture(Texture2D texture, System.Drawing.RotateFlipType sourceModification, Rectangle destination) {
    
                Stream sourceBuffer = new MemoryStream();
                texture.SaveAsPng(sourceBuffer, texture.Width, texture.Height);
    
                System.Drawing.Image sourceImage = System.Drawing.Image.FromStream(sourceBuffer);
    
                sourceBuffer = new MemoryStream();
                sourceImage.RotateFlip(sourceModification);
                sourceImage.Save(sourceBuffer, System.Drawing.Imaging.ImageFormat.Png);                       
    
                _batch.Draw(
                    Texture2D.FromStream(_graphicsDevice, sourceBuffer),
                    destination,
                    Color.White);
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="texture"></param>
            /// <param name="sourceModification"></param>
            /// <param name="destination"></param>
            /// <param name="source"></param>
            public void BakeTexture(Texture2D texture, System.Drawing.RotateFlipType sourceModification, Rectangle destination, Rectangle source) {
    
                Stream sourceBuffer = new MemoryStream();
                texture.SaveAsPng(sourceBuffer, texture.Width, texture.Height);
    
                System.Drawing.Image sourceImage = System.Drawing.Image.FromStream(sourceBuffer);
    
                sourceBuffer = new MemoryStream();
                sourceImage.RotateFlip(sourceModification);
                sourceImage.Save(sourceBuffer, System.Drawing.Imaging.ImageFormat.Png);
    
                _batch.Draw(
                    Texture2D.FromStream(_graphicsDevice, sourceBuffer),
                    destination,
                    source,
                    Color.White);
            }
    
            #endregion
    
            #region SpriteFont baking
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="font"></param>
            /// <param name="text"></param>
            /// <param name="location"></param>
            /// <param name="textColor"></param>
            public void BakeText(SpriteFont font, string text, Vector2 location, Color textColor) {
    
                _batch.DrawString(font, text, location, textColor);
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="font"></param>
            /// <param name="text"></param>
            /// <param name="location"></param>
            public void BakeTextCentered(SpriteFont font, string text, Vector2 location, Color textColor) {
    
                var shifted = new Vector2 {
                    X = location.X - font.MeasureString(text).X / 2,
                    Y = location.Y - font.MeasureString(text).Y / 2
                };
    
                _batch.DrawString(font, text, shifted, textColor);
            }
    
            #endregion
    
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public Texture2D GetTexture() {
    
                _batch.End();
                _graphicsDevice.SetRenderTarget(null);
    
                return _renderTarget;
            }
        }
    }
