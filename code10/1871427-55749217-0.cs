       static void test()
        {
            int ID, I = 0; int SomeValue = 0;
            //if (File.Exists("CompetitorDataFile.txt"))
            //{
            string[] arr = new string[] { "01XX~78", "ba~7U", "m4~ro5" };
            I = arr.Length;
            ID = I + 1;
            var ss = Convert.ToString(ID);
            int val=0;
            for (int z = 0; z < arr.Length; z++)
            {
                string[] arr2 = arr[z].Split('~');
                if (SomeValue == checkConvertion(arr2[1] ))
                {
                  var  valid2 = false;
                }
            }
            //}
            //else
            //{
            //    ID = I;
            //    var res = Convert.ToString(ID);
            //}
        }
       static  int checkConvertion(string stringInput)
        {
            int val;
            var convertionResult = int .TryParse(stringInput, out val);
            // int.Parse(stringInput);  -- also you can use this
            return convertionResult ? val : 0;
        }
