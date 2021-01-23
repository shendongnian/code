    protected void btn1_Click(object sender, EventArgs e)
    {
        for (int i = 1; i < 101; i++)
        {
            if (i % 3 == 0 & i % 5 == 0)
            {
                Response.Write("fizzbuzz" + ",");
            }
            else if (i % 3 == 0)
            {
                Response.Write("fizz" + ",");
            }
            else if (i % 5 == 0)
            {
                Response.Write("buzz" + ",");
            }
            else
            {
                i = i + 0; //this is totally useless
                Response.Write(i + ",");
            }
            //Response.Write(i +","); //This will always write the number, even if you wrote fizz or buzz
        }
    }
