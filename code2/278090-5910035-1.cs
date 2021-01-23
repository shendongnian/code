    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Collections;
    using System.Threading;
    
    namespace threade
    {
        //Delegate function for work with Invoke function
        public delegate void swaps(int i, int j, Button[] btns);
    
        public partial class Threads : Form
        {
            Thread t1;
            Thread t2;
            Thread t3;
    
            //num= num of buttons
            public const int num = 30;
    
            Button[] btns1 =new Button[num];
            Button[] btns2 =new Button[num];
            Button[] btns3 =new Button[num];
    
            //num array for bubble sort & quick sort
            public int[] nums = new int[num];
            //mnum array for merge sort
            public int[] mnums = new int[num];
    
            public Threads()
            {
                InitializeComponent();
                //Create buttons function:
                Create_buttons();
               
                ////thread starts
            }
            public void Create_buttons() {
                int space = 10;
                for (int i = 0; i < num; i++) {
                    mnums[i]=nums[i] = (new Random(DateTime.Now.Millisecond + i)).Next(20, 150);
                    btns1[i] = new Button();
                    btns1[i].Top = bubpanel.Height - nums[i] - 10;
                    btns1[i].Left = space;
                    btns1[i].Size = new Size(35, nums[i]);
                    btns1[i].Text = btns1[i].Size.Height.ToString();
                    btns1[i].BackColor = Color.Gold;
                    bubpanel.Controls.Add(btns1[i]);
    
                    btns2[i] = new Button();
                    btns2[i].Top = quickpanel.Height - nums[i] - 10;
                    btns2[i].Left = space;
                    btns2[i].Size = new Size(35, nums[i]);
                    btns2[i].Text = btns1[i].Size.Height.ToString();
                    btns2[i].BackColor = Color.LightBlue;
                    quickpanel.Controls.Add(btns2[i]);
    
                    btns3[i] = new Button();
                    btns3[i].Top = mergepanel.Height - mnums[i] - 10;
                    btns3[i].Left = space;
                    btns3[i].Size = new Size(35, mnums[i]);
                    btns3[i].Text = btns1[i].Size.Height.ToString();
                    btns3[i].BackColor = Color.Pink;
                    mergepanel.Controls.Add(btns3[i]);
                    space += 46;
                    t1 = new Thread(new ThreadStart(sort1));
                    t2 = new Thread(new ThreadStart(sort2));
                    t3 = new Thread(new ThreadStart(sort3));
                }
            }
    
            void sort1()
            {
                bsort(btns1, num);
            }
            void sort2()
            {
                qsort(0, num-1, btns2);
            }
            void sort3()
            {
                mgsort(0, num);
            }
    
            //swap for b-sort & qsorts  
            void swap(int i, int j, Button[] btns)
            {
                Button aa = new Button();
                aa = btns[i];
                btns[i] = btns[j];
                btns[j] = aa;
    
                int t = btns[i].Location.X;
                btns[i].Location = new Point(btns[j].Location.X, btns[i].Location.Y);
                btns[j].Location = new Point(t, btns[j].Location.Y);
            }
    
            //partition
            int part(int l, int h, Button[] btns)
            {
                int i, j=l;
                int p = btns[l].Size.Height;
                for (i = l +1; i <= h; i++)
                    if (btns[i].Size.Height < p)
                    {
                        j++;
                        //swap button[i] and button[j]
                        Invoke(new swaps(swap), i, j, btns);
                        Thread.Sleep(100);
                    }
                int s = j;
                Invoke(new swaps(swap), l, j, btns);
                Thread.Sleep(100);
                return s;
            }
            //qsort
            void qsort(int l, int h, Button[] btns)
            {
                if (h > l)
                {
                    int p = part(l, h, btns);
                    qsort(l, p-1,btns);
                    qsort(p+1, h,btns);
                }
            }
            //bubble sort
            void bsort(Button[] btns,int n)
            {
                for (int i = 0; i < n-1; i++)                             
                    for(int j=i+1;j<n;j++)
                        if (btns[j].Size.Height < btns[i].Size.Height)
                        {
                            //swap button[i] and button[j]
                            Invoke(new swaps(swap), i, j, btns);
                            Thread.Sleep(100);
                        }
            }
            //mgsort        
            void merge(int l, int m, int h)
            {
                int i = l, j = m + 1, k = l;
                int[] u = new int[num];
    
                while (i <= m && j <= h)
                {
                    if (j == num) break;
                    else if (mnums[i] < mnums[j])
                    {
                        u[k++] = mnums[i++];
                    }
                    else
                    {
                        u[k++] = mnums[j++];
                    }
                }
                if (i <= m)
                {
                    for (int q = k; q <= h; q++)
                        if (i < num && q < num)
                        {
                            u[q] = mnums[i++];
                        }
                }
                else
                    for (int w = k; w <= h; w++)
                        if (j < num && w < num)
                        {
                            u[w] = mnums[j++];
                        }
                for (int r = l; r <= h; r++)
                {
                    if (l < num && r < num)
                    {
                        mnums[r] = u[l++];
                        
                        //swap button[r] and button[mnums[r]]
                        Invoke(new swaps(swap),r, search(mnums[r]), btns3);
                        Thread.Sleep(100);
                    }
                }
            }
            
            //for swaping in merge sort needed
            int search(int x)
            {
                for (int j = 0; j < num; j++)
                    if (btns3[j].Size.Height == x)
                        return j;
                return 0;
            }
            //merge sort
            void mgsort(int l, int h)
            {
                if (l >= h) return;
                    int m = (l + h) / 2;
                    mgsort(l, m);
                    mgsort(m+1, h);
                    merge(l, m, h); 
            }
    
            private void runbtn_Click(object sender, EventArgs e)
            {
                t1.Start();
                t2.Start();
                t3.Start();
                runbtn.Visible = false;
                pausebtn.Visible = true;
            }
    
            private void pausebtn_Click(object sender, EventArgs e)
            {
                if (t1.ThreadState.ToString() != "Stopped")
                    t1.Suspend();
                if (t2.ThreadState.ToString() != "Stopped")
                    t2.Suspend();
                if (t3.ThreadState.ToString() != "Stopped")
                    t3.Suspend();
                pausebtn.Visible = false;
                resumebtn.Visible = true;
            }
    
            private void resumebtn_Click(object sender, EventArgs e)
            {
                if (t1.ThreadState.ToString() != "Stopped")
                        t1.Resume();
                if (t2.ThreadState.ToString() != "Stopped")
                        t2.Resume();
                if (t3.ThreadState.ToString() != "Stopped")
                        t3.Resume();
                resumebtn.Visible = false;
                pausebtn.Visible = true;
            }
    
            private void stopbtn_Click(object sender, EventArgs e)
            {
                if (t1.ThreadState.ToString() != "Suspended")
                    t1.Abort();
                if (t2.ThreadState.ToString() != "Suspended")
                    t2.Abort();
                if (t3.ThreadState.ToString() != "Suspended")
                    t3.Abort();
                stopbtn.Visible = true;
    
                for (int i = 0; i < num; i++)
                {
                    bubpanel.Controls.Remove(btns1[i]);
                    mergepanel.Controls.Remove(btns3[i]);
                    quickpanel.Controls.Remove(btns2[i]);
                }
                Create_buttons();
                runbtn.Visible = true;
                pausebtn.Visible = false;
            }
        }
    }
