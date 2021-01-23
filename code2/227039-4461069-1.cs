    // There must be a nicer way of doing this bit
    var blackPlusWhite =  secret.ToLookup(a => a)
                                 .Join(guess.ToLookup(a => a),
                                       g => g.Key,
                                       g => g.Key,
                                      (g1, g2) => Math.Min(g1.Count(), g2.Count()))
                                 .Sum();   
    var black = guess.Zip(secret, (g, s) => g == s)
                     .Count(correct => correct); 
   
    var white = blackPlusWhite - black;
