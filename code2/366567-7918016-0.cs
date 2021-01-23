        private int _counter; //It defaults to 0, setting it to 0 is redundant.
        public int Counter
        {
            get { return _counter; }
            set
            {
                if (Equals(_counter, value)) return;
                if (value < 0) return;
                if ((loadedHouses != null) && (value > loadedHouses.Count) return;
                _counter = value;
                GetHouse();
            }
        }
        ...
        private void GetFirst()
        {
            Counter = 0;
        }
        private void Getprevious()
        {
            Counter--;
        }
        private void Getnext()
        {
            Counter++;
        }
        private void Getlast()
        {
            //Counter = results.Count(); //WTF? Why results.Count() when results is a string??
            Counter = ((loadedHouses == null) ? 0 : loadedHouses.Count);
        }
