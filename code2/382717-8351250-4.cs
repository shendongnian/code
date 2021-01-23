            string test = "testＴＥＳＴ！＋亜+123!１２３";
            var widechars = test.Where(c => isZenkaku(c.ToString())).ToList();
            foreach (var c in widechars)
            {
                Console.WriteLine(c); //result is ＴＥＳＴ！＋亜１２３
                
            }
