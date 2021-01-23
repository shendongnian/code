        public int BinaryToDecimal(string data)
        {
            int result = 0;
            char[] numbers = data.ToCharArray();
            try
            {
                if (!IsNumeric(data))
                    error = "Invalid Value - This is not a numeric value";
                else
                {
                    for (int counter = numbers.Length; counter > 0; counter--)
                    {
                        if ((numbers[counter - 1].ToString() != "0") && (numbers[counter - 1].ToString() != "1"))
                            error = "Invalid Value - This is not a binary number";
                        else
                        {
                            int num = int.Parse(numbers[counter - 1].ToString());
                            int exp = numbers.Length - counter;
                            result += (Convert.ToInt16(Math.Pow(2, exp)) * num);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return result;
        }
