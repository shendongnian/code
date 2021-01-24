    namespace ArrayProcess
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void process_Click(object sender, EventArgs e)
            {
    
                int sum = 0;
                string ind = "index";
                string message;
                int count = Convert.ToInt32(inputArray.Text);
                int[] varray = new int[count];
                for (int i=1; i <= count; i++)
                {
                    varray[i-1] = Convert.ToInt32(Interaction.InputBox(message="enter the value of array number "+i));
                    sum += varray[i-1];
                }
                //Refer your list box here to add newly added values to the list
                boxSum.Text = Convert.ToString(sum);
                boxAvg.Text = Convert.ToString(sum / count);  //calculate the average
            }
        }
    }
