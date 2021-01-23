    string test = "testＴＥＳＴ！123!１２３";
    var widechars = test.Where(c => c.ToString() == 
                         Strings.StrConv(c.ToString(), VbStrConv.Wide)).ToList();
    foreach (var c in widechars)
    {
         Console.WriteLine(c); // prints ＴＥＳＴ！１２３
    }
