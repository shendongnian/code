    var locker = new Object(); //I'd actually make this static, but it should end up as a closure and so still work
    var OutputBuffer = new StringBuilder();
    int score = 0;
    Parallel.ForEach(words, w => 
    {
       // We want to push as much of the work to the individual threads as possible.
       // If run in 1 thread, a stringbuilder per word would be bad.
       // Run in parallel, it allows us to do a little more of the work outside of locked code.
       var buf = new StringBuilder(w.Length + 5);
       string word = buf.Append(w.Where(c=>c!='U').ToArray()).Append(' ').Append(w.Length).ToString();
       lock(locker)
       {
           OutputBuffer.Append(word);
           score += w.Length;
       }
    });
    OutputBuffer.Append("Total = ").Append(score);
