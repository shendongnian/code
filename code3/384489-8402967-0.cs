    private static void outputNumOfTotalTags(Dictionary<string, int> list, int numOfTags)
        {
            Console.WriteLine("The original number of hashtags is: {0}\n", numOfTags);
            //foreach (KeyValuePair<string, int> pair in list) == you don't need the pair.
            foreach (int Value in list.Values)
            {
                //numOfTags = numOfTags + pair.Value; == a change since you don't need the pair.
                numOfTags = numOfTags + value;
            }
            Console.WriteLine("The total number of hashtags is: {0}\n", numOfTags);
            //} == This closing what ?!
        }
