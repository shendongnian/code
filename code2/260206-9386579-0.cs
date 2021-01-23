    This may help if you have a class assignment and your professor doesn't want you to use Array.Sort.
     private void button1_Click(object sender, EventArgs e)
            {
               
                 int[] numbers = {7,4,2,6,1,10,5,8,9,3};
                 SortArray(numbers);
                 foreach (int n in numbers)
                {
                    textBox1.Text = textBox1.Text + n.ToString() + ' ' ;
                                 
                }
            }
    
    public static void SortArray(int[] num)
            {
                int temp;
                 int count = 0;
               
                while(count < num.Length - 1)
                {     
                    int min = num[ count];
          
                    for (int x = count; x < num.Length; x++)
                    {
                        if (min > num[x])
                        {
                            temp = num[count];
                            min = num[x];
                            num[count] = num[x];
                            num[x] = temp;
    
                        }
    
                    }
                   count++;
               }
            }       
