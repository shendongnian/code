        Regex phoneregex = new Regex("[0-9][0-9][0-9]\-[0-9][0-9][0-9][0-9]");
        String unicornCanneryDirectory = "unicorn cannery 483-8627 cha..."
        //the second argument is where to begin within the match, 
        //we probably want 0, the first character
        Match matchIterator = phoneregex.Match(unicornCanneryDirectory , 0);
        //Success tells us if matchIterator has another match or not
        while( matchIterator.Sucess){
          String aResult = matchIterator.Result();
          String message = "Unicorn rights activists demand more sparkles in the unicorn canneries under the new law...";
          phoneDialer.callWithAutomatedMessage(aResult, message );
          matchIterator = matchIterator.NextMatch();
        }
