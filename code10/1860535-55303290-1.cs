    public static bool IsPalindrome(string word)
    {
            char[] temp = word.ToCharArray();
            Array.Reverse(temp);
            string emordnilap = new string(temp);
    
            if(word.Equals(emordnilap)){
                return true;    
            }
            else{
               return false;
            }
    }
