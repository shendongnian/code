    public class SplitComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var partsOfX = x.Split('.');
            int firstNumber;
            if (partsOfX.Length > 1 && int.TryParse(partsOfX[1], out firstNumber))
            {
                var secondNumber = Convert.ToInt32(y.Split('.')[1]);
                return firstNumber.CompareTo(secondNumber);
            }
            return x.CompareTo(y);
        }
    }
