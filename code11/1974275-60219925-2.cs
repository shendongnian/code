        void rec1(string[] strBox1, string[] strBox2, int i)
        {
            if (i < strBox1.Length)
            {
                rec2(strBox1[i], strBox2, 0);
                rec1(strBox1, strBox2, i++);
            }
        }
        void rec2(string str, string[] strBox2, int j)
        {
            Console.WriteLine(str + "," + strBox2[j]);
            if (j < strBox2.Length)
                rec2(str, strBox2, j++);
        }
        public int maint()
        {
             var txtBox1 = Textbox1.Split( new[] { Environment.NewLine },StringSplitOptions.None); //Returns a string array that contains the substrings in this instance that are delimited by ENTER '\n'
             var txtBox2 = Textbox2.Split( new[] { Environment.NewLine },StringSplitOptions.None);
            
             re1(   txtBox1 ,txtBox2,0); 
            
             return 0;
        }
