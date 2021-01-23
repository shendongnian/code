     class MyStringComparer : IComparer<string>
            {
                public int Compare(string x, string y)
                {
                    // your comparison logic
                    // split the string using '.' separator
                    // parse each string item in split array into an int
                    // compare parsed integers from left to right
                }
            }
