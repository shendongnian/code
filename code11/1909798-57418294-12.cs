        void TryToCoverTimePeriod(int family, int timeStart = 0, int timeEnd = 1440)
        {
            List<int[]> helperTimeCoverege = new List<int[]>(); //list of helper with coverege time that start before timeStart
            List<int[]> helperTimeCoveregeSecondary = new List<int[]>(); //list of helper with start time that start after timeStart
            for (int i = 0; i < helpers.Length; i++) {
                if (helpers[i][0] <= timeStart) {
                    if (CheckIfHelperAvable(i, timeStart, Math.Min(timeEnd, helpers[i][1])))
                        helperTimeCoverege.Add(new int[] { i, Math.Min(timeEnd, helpers[i][1]) - timeStart });
                } else if (helpers[i][1] < timeEnd) {
                    if (CheckIfHelperAvable(i, helpers[i][0], Math.Min(timeEnd, helpers[i][1])))
                        helperTimeCoveregeSecondary.Add(new int[] { i, helpers[i][0] });
                }
            }
            int[] bestHelper = new int[] { -1, 0 };
            if (helperTimeCoverege.Count > 0) {
                //get best helper
                foreach (int[] helper in helperTimeCoverege) {
                    if (helper[1] > bestHelper[1]) {
                        bestHelper[0] = helper[0];
                        bestHelper[1] = helper[1];
                    }
                }
                //setting schedule
                helpersSchedule[bestHelper[0]].Add(new int[] { family, timeStart, timeStart + bestHelper[1] });
                if (timeStart + bestHelper[1] < timeEnd) {
                    TryToCoverTimePeriod(family, timeStart + bestHelper[1], timeEnd); //not enough, need more helpers
                }
            } else {
                //get best helper
                foreach (int[] helper in helperTimeCoveregeSecondary) {
                    if (helper[1] > bestHelper[1]) {
                        bestHelper[0] = helper[0];
                        bestHelper[1] = helper[1];
                    }
                }
                //setting schedule
                helpersSchedule[bestHelper[0]].Add(new int[] { family, bestHelper[1], Math.Min(helpers[bestHelper[0]][1], timeEnd) });
                if (Math.Min(helpers[bestHelper[0]][1], timeEnd) < timeEnd) {
                    TryToCoverTimePeriod(family, Math.Min(helpers[bestHelper[0]][1], timeEnd), timeEnd); //not enough, need more helpers
                }
            }
        }
