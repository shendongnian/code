        public string insertSpacesAtEnd(string input, int longest)
        {
            string output = input;
            string spaces = "";
            int inputLength = input.Length;
            int numToInsert = longest - inputLength;
            for (int i = 0; i < numToInsert; i++)
            {
                spaces += " ";
            }
            output += spaces;
            return output;
        }
        public int findLongest(List<Results> theList)
        {
            int longest = 0;
            for (int i = 0; i < theList.Count; i++)
            {
                if (longest < theList[i].title.Length)
                    longest = theList[i].title.Length;
            }
            return longest;
        }
        ////Usage////
        for (int i = 0; i < storageList.Count; i++)
        {
            output += insertSpacesAtEnd(storageList[i].title, longest + 5) +   storageList[i].rank.Trim() + "     " + storageList[i].term.Trim() + "         " + storageList[i].name + "\r\n";
        }
