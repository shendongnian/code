        Regex phoneregex = new Regex("[0-9][0-9][0-9]\-[0-9][0-9][0-9][0-9]");
        String unicornCanneryDirectory = "unicorn cannery 483-8627 cha..."
        String numbersToCall = "";
        //the second argument is where to begin within the match, 
        //we probably want 0, the first character
        Match matchIterator = phoneregex.Match(unicornCanneryDirectory , 0);
        //Success tells us if matchIterator has another match or not
        while( matchIterator.Sucess){
          String aResult = matchIterator.Result();
          //we could manipulate our match now but I'm going to concatenate them all for later
          numbersToCall  += aResult + " ";
          matchIterator = matchIterator.NextMatch();
        }
        // use my concatenated matches now
        String message = "Unicorn rights activists demand more sparkles in the unicorn canneries under the new law...";
        phoneDialer.MassCallWithAutomatedMessage(aResult, message );
