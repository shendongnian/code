    string sentence = "10 cats, 20 dogs, 40 fish and 1 programmer";
     string[] digits= Regex.Split(sentence, @"\D+");
                 foreach (string value in digits)
                 {
                     int number;
                     if (int.TryParse(value, out number))
                     {
                         Debug.Log(value);
                     }
                 }
