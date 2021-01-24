            public void calculationFunction(Dictionary<String, List<String>> tr1, Dictionary<String, List<ArrayList>> v1, Dictionary<String, bool> v5,
                                            Dictionary<String, int> infoIndex, out List<String> minusLIST, out List<String> plusLIST)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                double num1 = 0; double num2 = 0; double num3 = 0; double number1 = 0; double number2 = 0; double number3 = 0; double thenum1 = 0; double thenum2 = 0; double thenum3 = 0;
                double NUM1 = 0; double NUM2 = 0; double NUM3 = 0; double NUMBER1 = 0; double NUMBER2 = 0; double NUMBER3 = 0; String str = ""; String num11 = ""; String num22 = ""; String num33 = "";
                String number11 = ""; String number22 = ""; String number33 = ""; double calc1 = 0;
                minusLIST = new List<String>(); plusLIST = new List<String>();
                List<String> minusLIST2 = new List<String>(); List<String> plusLIST2 = new List<String>(); object lockobj = new object();
                Parallel.ForEach(tr1, entry =>
                {
                    List<String> allparams = new List<String>(entry.Value);
                    if (allparams.Count == 10)
                    {
                        if (v5.ContainsKey(allparams[7]) && v5.ContainsKey(allparams[8]) && v5.ContainsKey(allparams[9]))
                        {
                            if (v5[allparams[7]] && v5[allparams[8]] && v5[allparams[9]])
                            {
                                //Calculate both calc scenarios!
                                num1 = (double)v1[allparams[0]][infoIndex[allparams[7]]][0]; number1 = (double)v1[allparams[0]][infoIndex[allparams[7]]][1]; thenum1 = (double)v1[allparams[0]][infoIndex[allparams[7]]][2];
                                num2 = (double)v1[allparams[1]][infoIndex[allparams[8]]][0]; number2 = (double)v1[allparams[1]][infoIndex[allparams[8]]][1]; thenum2 = (double)v1[allparams[1]][infoIndex[allparams[8]]][2];
                                num3 = (double)v1[allparams[2]][infoIndex[allparams[9]]][0]; number3 = (double)v1[allparams[2]][infoIndex[allparams[9]]][1]; thenum3 = (double)v1[allparams[2]][infoIndex[allparams[9]]][2];
                                NUM1 = num1; NUM2 = num2; NUM3 = num3; NUMBER1 = number1; NUMBER2 = number2; NUMBER3 = number3;
                                if (num1 <= 0 || number1 <= 0) { NUM1 = thenum1; NUMBER1 = thenum1; }
                                if (num2 <= 0 || number2 <= 0) { NUM2 = thenum2; NUMBER2 = thenum2; }
                                if (num3 <= 0 || number3 <= 0) { NUM3 = thenum3; NUMBER3 = thenum3; }
                                if (NUM1 > 0 && NUM2 > 0 && NUM3 > 0 && NUMBER1 > 0 && NUMBER2 > 0 && NUMBER3 > 0)
                                {
                                    lock (lockobj)
                                    {
                                        str = ""; num11 = ""; num22 = ""; num33 = ""; number11 = ""; number22 = ""; number33 = "";
                                        if (num1 > 0 && num2 > 0 && num3 > 0 && number1 > 0 && number2 > 0 && number3 > 0) { } else { str = string.Format("{0:F10}", thenum1) + " / " + string.Format("{0:F10}", thenum2) + " / " + string.Format("{0:F10}", thenum3); }
                                        if (num1 <= 0) { num11 = "0"; num1 = thenum1; } else { num11 = string.Format("{0:F10}", num1); }
                                        if (num2 <= 0) { num22 = "0"; num2 = thenum2; } else { num22 = string.Format("{0:F10}", num2); }
                                        if (num3 <= 0) { num33 = "0"; num3 = thenum3; } else { num33 = string.Format("{0:F10}", num3); }
                                        if (number1 <= 0) { number11 = "0"; number1 = thenum1; } else { number11 = string.Format("{0:F10}", number1); }
                                        if (number2 <= 0) { number22 = "0"; number2 = thenum2; } else { number22 = string.Format("{0:F10}", number2); }
                                        if (number3 <= 0) { number33 = "0"; number3 = thenum3; } else { number33 = string.Format("{0:F10}", number3); }
                                        //Calculate
                                        if (allparams[6] == "0")
                                        {
                                            calc1 = ((num1 * number2 * number3) - 45) / 10;
                                        }
                                        else
                                        {
                                            calc1 = (((num1 * number2) / number3) + 45) / 10;
                                        }
                                        //String
                                        str = calc1 + "," + allparams[0] + " - " + allparams[1] + " - " + allparams[2] + "," +
                                                                             allparams[3] + " - " + allparams[4] + " - " + allparams[5] + "," +
                                                                             num11 + " / " + num22 + " / " + num33 + "," +
                                                                             number11 + " / " + number22 + " / " + number33 + "," +
                                                                             str + "," +
                                                                             calc1 + "%";
                                        if (calc1 > 0) { plusLIST2.Add(str); }
                                        else
                                        {
                                            minusLIST2.Add(str);
                                        }
                                    }
                                }
                            }
                        }
                    }
                });
                plusLIST = new List<String>(plusLIST2);
                minusLIST = new List<String>(minusLIST2);
            }
