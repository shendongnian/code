     public static void  DoStemmer(String[] args)
            {
                String[] Final = new string[args.Length];
                if (args.Length == 0)
                {
                    return ;
                }
                char[] w = new char[501];
                Stemmer s = new Stemmer();
               
                for (int i = 0; i < args.Length; i++)
                {
                    //try
                    //{
                    
                    byte[] array = Encoding.ASCII.GetBytes(args[i]);
                   //using (FileStream _in = new FileStream(args[i], FileMode.Open, FileAccess.Read))
                    //try
                    //{
                    //Boolean Flag = false;
                    int Size=array.Length;
                    int Count = 0;
                    int j = 0;
                    Array.Clear(w, 0, w.Length);
                   
                    foreach (byte element in array)
                    {
                        Count++;
                        int ch = element;
                        if (Char.IsLetter((char)ch))
                        {
                           
                            //while (true)
                            //{
                                ch = Char.ToLower((char)ch);
                                w[j] = (char)ch;
                                if (j < 500)
                                    j++;
                              //  ch = _in.ReadByte();
                                if (Count==Size)
                                {
                                    /* to test add(char ch) */
                                    for (int c = 0; c < j; c++)
                                        s.add(w[c]);
                                    /* or, to test add(char[] w, int j) */
                                    /* s.add(w, j); */
                                    s.stem();
    
                                    String u;
    
                                    /* and now, to test toString() : */
                                    u = s.ToString();
    
                                    /* to test getResultBuffer(), getResultLength() : */
                                    /* u = new String(s.getResultBuffer(), 0, s.getResultLength()); */
    
                                    Final[i] = u;
                                    break;
                                }
                            //}
                        }
                        if (ch < 0)
                            break;
                        Final[i] = ch.ToString();
                    }
                    //    }
                    //    catch (IOException)
                    //    {
                    //        MessageBox.Show("o");
                    //        break;  
    
                    //    }
                    //}
                    //catch (FileNotFoundException)
                    //{
                    //    break;
                    //    MessageBox.Show("no");
    
                    //}
              
                }
    
                FileStream sw = new FileStream(@"D:\patttt.txt", FileMode.CreateNew, FileAccess.Write, FileShare.Read);
                StreamWriter fs = new StreamWriter(sw);
               
                for (int jj = 0; jj < Final.Length; jj++)
                    fs.WriteLine(Final[jj]);
            } 
