        public static int   CalculateTotalOfSingles       (int pipNumber)
        {
            //
            var myScore = 0;
            foreach (var myDie in Roll5Player.MyHand.Dice)
            {
                {   if (myDie.Pips == pipNumber)
                    myScore+= pipNumber;
                }
            }
            //
            return myScore;
        }
        public static int   CalculateDicePips       ()
        {
            //
            var myScore = 0;
            foreach (var myDie in Roll5Player.MyHand.Dice)
            {
                {myScore += myDie.Pips;
                }
            }
            //
            return myScore;
        }
        //
        //
        //
        public static int   CalculateTotalOfAllSingles    (int pipNumber)
        {
            //
            var myScore = 0;
            for (int i = 1; i <= 6; i++)
            {
                myScore += pipNumber;
            }
            //
            return myScore;
        }
        public static bool  CalculateIsNOfaKind     (int count)
        {
            //
            for (var index = 1; index <= 6; index++)
            {
                var cntr = 0;
                foreach (var myDie in Roll5Player.MyHand.Dice)
                {
                    if (myDie.Pips == index)
                        cntr++;
                }
                //
                if (cntr == count)
                {
                    return true;
                    ;
                }
            }
            //
            return false;
        }
        public static int   CalculateNOfaKind       (int count  )
        {
            //
            var myScore = 0;
            for (var index = 1; index <= 6; index++)
            {
                var cntr = 0;
                foreach (var myDie in Roll5Player.MyHand.Dice)
                {
                        if (myDie.Pips == index)
                            cntr++;
                }
                //
                if (cntr >= count)
                {   myScore = CalculateDicePips();
                    return myScore;
                    ;
                }
            }
            //
            return myScore;
        }
        /// 
        public static int   CaluclateFullHouse      (           )
        {
            // 
            var myScore = 0;
            var cntr    = new int[6];
            for (var index = 1; index <= 6; index++)
            {
                foreach (var myDie in Roll5Player.MyHand.Dice)
                {
                    if (myDie.Pips == index)
                        cntr[index-1]++;
                }
            }
            //
            var boolCondA = false;
            var boolCondB = false;
            foreach (var i in cntr)
            {
                if (i == 3)
                {boolCondA = true;
                    break;
                }
            }
            if (boolCondA)
            {
                foreach (var i in cntr)
                {
                    if (i == 2)
                    {boolCondB = true;
                        break;
                    }
                }
            }
            //
            if (boolCondB ) 
                myScore = CalculateDicePips();
            //
            //
            //
            return myScore;
        }
        public static int   CaluclateStraights      (int straightCount, int score)
        {
            // 
            var tempPip     = 0;
            var myScore     = 0;
            var isFirstIteration = true;
            var cntr = 0;
            int[] sortedDice = new int[5];
            var sortedDiceLise = new List<int>();
            foreach (var myDie in Roll5Player.MyHand.Dice)
            {
                sortedDiceLise.Add(myDie.Pips);
            }
            sortedDiceLise.Sort();
            foreach (var myDie in sortedDiceLise)
            {
                //
                //
                if (!isFirstIteration)
                {
                    if (myDie == tempPip + 1)
                        cntr++;
                }
                //
                isFirstIteration = false;
                tempPip = myDie;
            }
            if (cntr == straightCount - 1)
            {myScore = score;
            }
            //
            //
            //
            return myScore;
        }
        public static int   CalculateYahtzee        ()
        {
            //
            for (var index = 1; index <= 6; index++)
            {
                var cntr = 0;
                foreach (var myDie in Roll5Player.MyHand.Dice)
                {
                    if (myDie.Pips == index)
                        cntr++;
                }
                //
                if (cntr == 5)
                {
                    return 50;
                    ;
                }
            }
            //
            return 0;
        }
