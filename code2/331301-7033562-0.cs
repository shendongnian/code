    using System;
    using System.Collections.Generic;
    
    namespace RandomString
    {
        class Program
        {
            static void Main(string[] args)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                Dictionary<char, int> chars = new Dictionary<char, int> { { 'a', 2 }, { 'b', 3 }, { 'c', 1 } };
    
                // Convert to a string with all chars
                string basestring = "";
                foreach (var pair in chars)
                {
                    basestring += new String(pair.Key, pair.Value);
                }
    
                // Randomize the string
                string randomstring = "";
                while (basestring.Length > 0)
                {
                    int randomIndex = rnd.Next(basestring.Length);
                    randomstring += basestring.Substring(randomIndex, 1);
                    basestring = basestring.Remove(randomIndex, 1);
                }
    
                // Now fix 'violations of the rule
                // this can be optimized by not starting over each time but this is easier to read
                bool done;
                do
                {
                    Console.WriteLine("Current string: " + randomstring);
                    done = true;
                    char lastchar = randomstring[0];
                    for (int i = 1; i < randomstring.Length; i++) 
                    {                    
                        if (randomstring[i] == lastchar) 
                        {
                            // uhoh violation of the rule. We pick a random position to move it to
                            // this means it gets placed at the nth location where it doesn't violate the rule
                            Console.WriteLine("Violation at position {0} ({1})", i, randomstring[i]);
    
                            done = false;
                            char tomove = randomstring[i];
                            randomstring = randomstring.Remove(i, 1);
                            int putinposition = rnd.Next(randomstring.Length);
                            Console.WriteLine("Moving to {0}th valid position", putinposition);
    
                            bool anyplacefound;
                            do
                            {
                                anyplacefound = false;
                                for (int replace = 0; replace < randomstring.Length; replace++)
                                {
                                    if (replace == 0 || randomstring[replace - 1] != tomove)
                                    {
                                        // then no problem on the left side
                                        if (randomstring[replace] != tomove)
                                        {
                                            // no problem right either. We can put it here
                                            anyplacefound = true;
                                            if (putinposition == 0)
                                            {
                                                randomstring = randomstring.Insert(replace, tomove.ToString());
                                                break;
                                            }
                                            putinposition--;
                                        }
                                    }
                                }
                            } while (putinposition > 0 && anyplacefound);
    
                            break;
                        }
                        lastchar = randomstring[i];
                    }
    
                } while (!done);
    
                Console.WriteLine("Final string: " + randomstring);
                Console.ReadKey();
            }
        }
    }
