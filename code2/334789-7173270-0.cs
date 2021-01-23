    public class DelayedImagedList : Component
    {
        // Item1 = Dispose for the image.
        // Item2 = At creation: the method to load the image. After loading: the method to return the image.
        // Item3 = The original filename.
        private List<Tuple<Action, Func<Image>, string>> _images = new List<Tuple<Action,Func<Image>,string>>();
        private Dictionary<string, int> _imageKeyMap = new Dictionary<string, int>();
        // Access images.
        public Image this[string key] { get { return _images[_imageKeyMap[key]].Item2(); } }
        public Image this[int index] { get { return _images[index].Item2(); } }
        public int Count { get { return _images.Count; } }
        // Use this to add an image according to its filename.
        public void AddImage(string key, string filename) { _imageKeyMap.Add(key, AddImage(filename)); }
        public int AddImage(string filename)
        {
            var index = _images.Count;
            _images.Add(Tuple.Create<Action, Func<Image>, string>(
                () => {}, // Dispose
                () => // Load image.
                {
                    var result = Image.FromFile(filename);
                    // Replace the method to load the image with one to simply return it.
                    _images[index] = Tuple.Create<Action, Func<Image>, string>(
                        result.Dispose, // We need to dispose it now.
                        () => result, // Just return the image.
                        filename);
                    return result;
                }, 
                filename));
            return index;
        }
        // This will unload an image from memory.
        public void Reset(string key) { Reset(_imageKeyMap[key]); }
        public void Reset(int index)
        {
            _images[index].Item1(); // Dispose the old value.
            var filename = _images[index].Item3;
            _images[index] = Tuple.Create<Action, Func<Image>, string>(
                () => { }, 
                () =>
                {
                    var result = Image.FromFile(filename);
                    _images[index] = Tuple.Create<Action, Func<Image>, string>(
                        result.Dispose, 
                        () => result, 
                        filename);
                    return result;
                }, 
                filename);
        }
        // These methods are available on ImageList.
        public void Draw(Graphics g, Point pt, int index) { g.DrawImage(this[index], pt); }
        public void Draw(Graphics g, int x, int y, int index) { g.DrawImage(this[index], x, y); }
        public void Draw(Graphics g, int x, int y, int width, int height, int index) { g.DrawImage(this[index], x, y, width, height); }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var val in _images) { val.Item1(); }
                _images.Clear();
                _imageKeyMap.Clear();
            }
            base.Dispose(disposing);
        }
    }
