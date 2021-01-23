    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Collections;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            ArrayList inputValue = new ArrayList();
            int avgValue = 0;
            bool isFinish = false;
            private void button1_Click(object sender, EventArgs e)
            {
                #region Init data
                isFinish = false;
                avgValue = 0;
                inputValue.Clear();
                listBox1.Items.Clear();
                //assum you input valid number without space and in desc sorting order 
                string[] arrNumber = textBox1.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int numberOfBreak = 3;
                int record = Convert.ToInt32(arrNumber[0]);//update the record with the maximum value of the array numbers
                for (int i = 0; i < arrNumber.Length; i++)
                {
                    inputValue.Add(Convert.ToInt32(arrNumber[i]));
                }
    
                foreach (object obj in inputValue)
                {
                    avgValue += (int)obj;
                }
                avgValue = avgValue / numberOfBreak;
                #endregion
                int lastIndex = 0;
                while (!isFinish)
                {
                    int index = GetIndex(lastIndex);
                    string sResult = "";
                    for (int i = lastIndex; i <= index; i++)
                    {
                        sResult += inputValue[i].ToString() + "-";
                    }
                    listBox1.Items.Add(sResult);
                    if (index + 1 < inputValue.Count)
                    {
                        lastIndex = index + 1;
                    }
                    sResult = "";
                }
            }
    
            private int GetIndex(int startIndex)
            {
                int index = -1;
                int gap1 = Math.Abs(avgValue - (int)inputValue[startIndex]);
                int tempSum = (int)inputValue[startIndex];
                if (startIndex < inputValue.Count - 1)
                {
                    
                    int gap2 = 0;
                    while (gap1 > gap2 && !isFinish)
                    {
                        for (int i = startIndex + 1; i < inputValue.Count; i++)
                        {
                            tempSum += (int)inputValue[i];
    
                            gap2 = Math.Abs(avgValue - tempSum);
                            if (gap2 <= gap1)
                            {
                                gap1 = gap2;
                                gap2 = 0;
                                index = i;
                                if (startIndex <= inputValue.Count - 1)
                                {
                                    startIndex += 1;
                                }
                                else
                                {
                                    isFinish = true;
                                }
                                if (startIndex == inputValue.Count - 1)
                                {
                                    index = startIndex;
                                    isFinish = true;
                                }
                                break;
                            }
                            else
                            {
                                index = i - 1;
                                break;
                            }
                        }
                    }
                  
    
                }
                else if (startIndex == inputValue.Count - 1)
                {
                    index = startIndex;
                    isFinish = true;
                }
                else
                {
                    isFinish = true;
                }
                return index;
            }
        }
    }
