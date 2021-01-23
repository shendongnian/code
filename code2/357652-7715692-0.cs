    for (int i = 0; i < da.Length; i++)
                    {
                        //replace char with number
                        string f = da[i].Replace("n", (i + 1).ToString());
                        disp.Text += f + "v";
                    }
