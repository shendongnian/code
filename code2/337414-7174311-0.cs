            string result;
            StreamReader SR;
            string S;
            SR=File.OpenText("H:\\Account.txt");
            S=SR.ReadToEnd();
            SR.Close();
            string words = S;
            words = words.Replace("\r", string.Empty);
            List<string> splitNewLine = words.Split('\n').ToList();
            for (int i = 0; i <= splitNewLine.Count() - 1; i++)
            {
                string checkUsername = (splitNewLine[i].Split(','))[0];
                string checkPassword = (splitNewLine[i].Split(','))[2];
                if (Username == checkUsername && Password == checkPassword)
                {
                    result = "Successfully logged in";
                    return result;
                    break;
                }
             }
            result = "Wrong Login Combination";
            return result;
