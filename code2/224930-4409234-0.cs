        private static readonly Key[] _konamiCode = new[] { Key.Up, Key.Up, Key.Down, Key.Down, Key.Left, Key.Right, Key.Left, Key.Right, Key.B, Key.A };
        int _konamiCurrentIndex = 0;
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.Key == _konamiCode[_konamiCurrentIndex])
            {
                _konamiCurrentIndex++;
                if (_konamiCurrentIndex == _konamiCode.Length)
                {
                    _konamiCurrentIndex = 0;
                    KonamiEasterEgg();
                }
            }
            else
            {
                _konamiCurrentIndex = 0;
            }
        }
        void KonamiEasterEgg()
        {
            // whatever you want to do when the Konami code is entered...
        }
