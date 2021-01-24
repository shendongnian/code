        public enum Seasons {
        Spring = 1,
        Summer = 2,
        Autumn = 3,
        Winter = 4
    }
    [System.Serializable]
    public class Date {
        [Header("General")]
        [SerializeField, ReadOnly] private int DaysInMonth = 29;
        [SerializeField, Min(1)] private float day;
        [SerializeField, Min(1)] private int season;
        [SerializeField, Min(1)] private int year;
        public float Day { get => day; private set => day = value; }
        public int Season { get => season; private set => season = value; }
        public int Year { get => year; private set => year = value; }
        public Seasons currentSeason;
        public Date(int startDay = 1, int startSeason = 1, int startYear = 420) {
            Day = startDay;
            Season = startSeason;
            currentSeason = (Seasons)Season;
            Year = startYear;
        }
        public void AdvanceDay() {
            Day++;
            if(Day > DaysInMonth) {
                Day = 1;
                AdvanceSeason();
            }
        }
        private void AdvanceSeason() {
            Season++;
            currentSeason = (Seasons)Season;
            if(Season > 4) {
                Season = 1;
                AdvanceYear();
            }
        }
        public Seasons GetCurrentSeason() {
            return (Seasons)Season;
        }
        private void AdvanceYear() {
            Year++;
        }
    }
}
