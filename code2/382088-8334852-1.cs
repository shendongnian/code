    class AnimatedTexture2D : Texture2D
    {
        int _numberOfImages;
        int _currentImage = 0;
        int _timeInterval;
        int _spriteWidth;
        public Rectangle DrawFromRectangle
        {
            get
            {
                return new Rectangle(_currentImage * _spriteWidth, 0, _spriteWidth, this.Height);
            }
        }
        public AnimatedTexture2D(Texture2D entireImage, int spriteWidth, int numberOfImages, int timeInterval)
            : base(entireImage.GraphicsDevice, entireImage.Width, entireImage.Height)
        {
            _numberOfImages = numberOfImages;
            _timeInterval = timeInterval;
            _spriteWidth = spriteWidth;
            Color[] data = new Color[entireImage.Width * entireImage.Height];
            entireImage.GetData<Color>(0, new Rectangle(0, 0, entireImage.Width, entireImage.Height), data, 0, entireImage.Width * entireImage.Height);
            this.SetData<Color>(data);
        }
        public void Animate(GameTime gameTime)
        {
            int totalImageTime = _timeInterval * _numberOfImages;
            int currentPoint = (int)gameTime.TotalGameTime.TotalMilliseconds % totalImageTime;
            _currentImage = currentPoint / _timeInterval;
        }
    }
