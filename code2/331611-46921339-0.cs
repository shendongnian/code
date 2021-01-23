    public String convertToRoman(int num)
    {    
        //Roman numerals to have <= 3 consecutive characters, the distances between deciaml values conform to this
        int[] decimalValue = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] romanNumeral = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        int num_cp = num; // copy the function parameter into num_cp
        String result = "";
    
        for (var i = 0; i < decimalValue.Length; i = i + 1)
        { //itarate through array of decimal values
            //iterate more to find values not explicitly provided in the decimalValue array
            while (decimalValue[i] <= num_cp)
            {
                result = result + romanNumeral[i];
                num_cp = num_cp - decimalValue[i];
            }
        }
        return result;
    }
