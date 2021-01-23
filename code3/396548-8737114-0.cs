    static void CountWordOccurrence()
    {
    //tell the user to enter their sentence
    Console.WriteLine("\nPlease enter the sentence to be tested.");
    //split their input into a string array
    string[] words = Console.ReadLine().Split(' ');
    //create our SortedList for holding our words and their count
    SortedList wordList = new SortedList();
    //variable to hold how many times a word appears in the string
    int numWords = 0;
    //now we loop through the string array
    foreach (string word in words)
    {
        //check and see if this word is in our list yet
        if (!(wordList.ContainsKey(word)))
        {
            //it isnt there so we add it with a value of 1
            //since it's the words first occurrence
            wordList.Add(word, 1);
            //increment our word counter
            numWords++;
        }
        else
        {
            //since the word dous exist we get the count of times it exists
            int iWordCount = (int)wordList[word];
            //we then increment the count for that word in the list
            wordList[word] = iWordCount + 1;
        }
    }
    //now we need an enumerator so we can traverse the list. For
    //this we will use the IDictionaryEnumerator and assign that the
    //value of the GetEnumerator method of our Sorted List
    IDictionaryEnumerator enumerator = wordList.GetEnumerator();
    //now we use the MoveNext method of our enumerator
    //to tell us whether we're at the end of our list
    while (enumerator.MoveNext())
    {
        //write a blank line
        Console.WriteLine();
        //now write our the occurrence of each word in the sentence using
        //the enumerator.Key (the word) and the enumerator.Value (the count)
        Console.WriteLine(string.Format("Word {0} Appeared {1} Times", enumerator.Key, enumerator.Value));
        Console.WriteLine();
    }
    Console.ReadKey(true);
