            //find most occuring character and count from below string
            string totest = "abcda12Zernn111y";
            string maxOccuringCharacter = "";
            int maxOccurence = 0;string currentLoopCharacter = ""; string updatedStringToTest = "";int cnt = 0;
            for (int i = 0; i < totest.Length; i++)
            {
                currentLoopCharacter = totest[i].ToString();
                updatedStringToTest = totest.Replace(currentLoopCharacter, "");
                cnt = totest.Length - updatedStringToTest.Length;
                if (cnt > maxOccurence)
                {
                    maxOccuringCharacter = currentLoopCharacter;
                    maxOccurence = cnt;
                }
                totest = updatedStringToTest;
            }
            Console.WriteLine("The most occuring character is {0} and occurence was {1}", maxOccuringCharacter, maxOccurence.ToString());
            Console.ReadLine();
       
