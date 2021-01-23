            public static String convert(int num)
            {
                String[] charsArray  = {"I", "IV", "V", "IX", "X", "XL", "L", "XC","C","CD","D","CM","M" };
                int[] charValuesArray = {1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000};
               
                String resultString = "";
                int temp = num;
                int [] resultValues = new int[13];
                // Generate an array which "char" occurances count
                for(int i = 12 ; i >= 0 ; i--)
                {
                    if((temp / charValuesArray[i]) > 0)
                    {
                        resultValues[i] = temp/charValuesArray[i];
                        temp = temp % charValuesArray[i];
                    }
                }
                // Print them if not occured do not print
                for(int j = 12 ; j >= 0 ; j--)
                {
                    for(int k = 0 ; k < resultValues[j]; k++)
                    {
                        resultString+= charsArray[j];
                    }
                }
                return resultString;
              }
           }
