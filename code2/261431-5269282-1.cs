    public static string CreateRandomPassword()  //If you are always going to want 8 characters then there is no need to pass a length argument
        {
            string _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789-";
            Random randNum = new Random((int)DateTime.Now.Ticks);  //Don't forget to seed your random, or else it won't really be random
            char[] chars = new char[8];
            //again, no need to pass this a variable if you always want 8
    
            for (int i = 0; i < 8; i++)
            {
                chars[i] = _allowedChars[randNum.Next(_allowedChars.Length)];
                //No need to over complicate this, passing an integer value to Random.Next will "Return a nonnegative random number less than the specified maximum."
            }
            return new string(chars);
        }
    
    
    protected void Button1_Click(object sender, EventArgs e)
        {
            userid.Text = "Your id is:     " + id.Text;
            if(id .Text!="")
            {
                password.Text = "Your password is: " + CreateRandomPassword(); 
            }
        }
