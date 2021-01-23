`using System;
using System.Text;
namespace MyEncriptionNameSpace
{
    class XorStringEncripter
    {
        private string __passWord;
        public XorStringEncripter(string password)
        {
            if (password.Length == 0)
            {
                throw new Exception("invalide password");
            }
            __passWord = password;
        }
        public string encript(string stringToEncript)
        {
            return __encript(stringToEncript);
        }
        public string decript(string encripTedString)
        {
            return __encript(encripTedString);
        }
        public string __encript(string stringToEncript)
        {
            var encriptedStringBuilder = new StringBuilder(stringToEncript.Length);
            int positionInPassword = 0;
            for (int i = 0; i < stringToEncript.Length; i++)
            {
                __corectPositionInPassWord(ref positionInPassword);
                encriptedStringBuilder.Append((char)((int)stringToEncript[i] ^ (int)__passWord[positionInPassword]));
                ++positionInPassword;
            }
            return encriptedStringBuilder.ToString();
        }
        private void __corectPositionInPassWord(ref int positionInPassword)
        {
            if (positionInPassword == __passWord.Length)
            {
                positionInPassword = 0;
            }
        }
    }
}`
actualy encript and decript do the same thing , I provided bouth to avoid confusion on using the same function for bouth encription and decrition. This is because if you have a nuber A and you xor it with B and you obtain C then if you xor C and B you get A.  
A xor B = C  --->  C xor B = A
