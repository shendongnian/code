        static int min = 0;
        static int max = 100;
        static int steps = 11; 
        private ObservableCollection<string> restartDelayTimeList = new ObservableCollection<string> (
            Enumerable.Range(0, steps).Select(l1 => (min + (max - min) * ((double)l1 / (steps - 1))).ToString())
        );
