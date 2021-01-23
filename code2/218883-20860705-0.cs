                    int test = 123456782;
                    string temp = "";
                    bool good = false;
                    foreach(char c in test.ToString().Substring(0, 8))
                    {
                        //the character codes for digits follow the same odd/even pattern as the digits
                        if(c % 2 == 1)
                        {
                            temp += c;
                        }
                        else
                        {
                            temp += (int.Parse(c.ToString()) * 2).ToString();
                        }
                    }
                    int temp2 = temp.Sum((x => int.Parse(x.ToString())));
                    if(((temp2 - (temp2 % 10)) + 10) - temp2 == (test % 10))
                        good = true;
