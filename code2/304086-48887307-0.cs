            string vowelList = ("aeiouAEIOU");
            int i = 0;
            int j = 0;
            int vowelCount = 0;
            string main = textBox1.Text;  /or Console.ReadLine();
            while (j < main.Length)
            {
                while (i < vowelList.Length)
                {
                    if (main[j] == vowelList[i])
                    {
                        vowelCount++;
                    }
                
                    i++; 
                }
                j = j + 1;
                i = 0;
            }
            label1.Text = ("Number of vowels in sentence is :" + vowelCount);  /or Console.Writeline ("Number of vowels in sentence is:  " + vowelCount
