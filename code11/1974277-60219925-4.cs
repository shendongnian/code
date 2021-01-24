            static void rec1(string[] strBox1, string[] strBox2, int i)
            {
                if (i < strBox1.Length)
                {
                    rec2(strBox1[i], strBox2, 0);
                    rec1(strBox1, strBox2, i+=1);
                }
            }
            static void rec2(string str, string[] strBox2, int j)
            {
                
                
                if (j < strBox2.Length)
                {
                    Console.WriteLine(str.Trim() + "," + strBox2[j].Trim());
                    rec2(str, strBox2, j +=1);
                }
               
            }
    
            static void Main(string[] args)
            {
                var txtBox1 = listOneBox.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); //Returns a string array that contains the substrings in this instance that are delimited by ENTER '\n'
                var txtBox2 = listTwoBox.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    
                rec1(txtBox1, txtBox2, 0);
                
            }
