    public class ViewModel
    {
        private int score;
        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                if (this.score != value)
                {
                    this.score = value;
                    // Notify that this property has changed
                    NotifyOfPropertyChange(() => this.Score);
                    // Notify that a dependant property has changed
                    NotifyOfPropertyChange(() => this.Total);
                }
            }
        }
        private int multiplier;
        public int Multiplier
        {
            get
            {
                return this.multiplier;
            }
            set
            {
                if (this.multiplier != value)
                {
                    this.multiplier = value;
                    // Notify that this property has changed
                    NotifyOfPropertyChange(() => this.Multiplier);
                    // Notify that a dependant property has changed
                    NotifyOfPropertyChange(() => this.Total);
                }
            }
        }
        public int Total
        {
            get
            {
                return this.Score * this.Multiplier;
            }
        }
    }
