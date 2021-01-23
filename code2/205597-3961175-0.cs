    public partial class Task {
        public DateTime DueDate {
            get {
                return (DateTime.Now);
            }
            set {
                this.Due = value;
            }
        }
        [Range(0, 23)]
        public byte DueTimeHour {
            get {
                return (0);
            }
            set {
                if (this.Due.HasValue) {
                    this.Due = DateTime.Parse(this.Due.Value.ToShortDateString() + " " + value + ":00:00");
                };
            }
        }
        [Range(0, 59)]
        public byte DueTimeMinute {
            get {
                return (0);
            }
            set {
                if (this.Due.HasValue) {
                    this.Due = DateTime.Parse(this.Due.Value.ToString("M/d/yyyy h") + ":" + value + ":00");
                };
            }
        }
        public string DueTimePostfix {
            get {
                return (string.Empty);
            }
            set {
                if (this.Due.HasValue) {
                    this.Due = DateTime.Parse(this.Due.Value.ToString("M/d/yyyy h:m") + " " + value);
                };
            }
        }
    }
