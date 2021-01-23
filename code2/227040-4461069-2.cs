    // There must be a nicer way of doing this bit
    var blackPlusWhite = secret.GroupBy(sNum => sNum)
                               .Join(guess.GroupBy(gNum => gNum),
                                     g => g.Key,
                                     g => g.Key,
                                    (g1, g2) => Math.Min(g1.Count(), g2.Count()))
                               .Sum();   
    var black = guess.Zip(secret, (gNum, sNum) => gNum == sNum)
                     .Count(correct => correct); 
   
    var white = blackPlusWhite - black;
