    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Collections;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            ArrayList arraylist =new ArrayList();
            private void Form1_Load(object sender, EventArgs e)
            {
                arraylist.Add("This is line1");
                arraylist.Add("Jack is good boy");
                arraylist.Add("Azak is a child");
                arraylist.Add("Mary has a chocolate");
                MessageBox.Show(GetSentenceFromFirstChar('J'));
    
            }
            public string GetSentenceFromFirstChar(char firstcharacter)
            {
                bool find=false;
                int index=-1;
                for (int i = 0; i < arraylist.Count; i++)
                {
                    if ((char)arraylist[i].ToString()[0] == firstcharacter)
                    {
                        index = i;
                        find = true;
                        break;
                    }
                }
                if (find)
                {
                    return arraylist[index].ToString();
                }
                else
                {
                    return "not found";
                }
            }
    
         
        }
    }
