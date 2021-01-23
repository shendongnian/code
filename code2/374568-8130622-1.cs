    public static class Class1
    {
        public static string GetIsValidNumberMessgae(string text)
        {
            string message;
            int number;
            if(int.TryParse(text,out number))
            {
                if (number > 10)
                    message="Number must be below 10";
                else 
                    message="Good !  You entered : " + number;
            }
            else
                message="Not valid number";
            return message;
        }
    }
