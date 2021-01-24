      using System.Text.RegularExpressions;
      ...
      string text = 
        @"Text with punctuation: comma, full stop. Apostroph's and ""quotation?"" - ! Yes!";
      var result = Regex.Split(text, @"\p{P}");
      Console.Write(string.Join(Environment.NewLine, result));
