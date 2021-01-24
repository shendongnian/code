        private void StudentButton_Click(object sender, EventArgs e)
        {
            string studentIdString = this.TEXTBOXNAME.Text; // This fetches the string from the input box and stores it. Replace TEXTBOXNAME with the name of your textbox that holds the ID.
            bool inputIsNumber = Int32.TryParse(studentIdString , out studentIdInt); //Int32 TryParse tries to convert a given string into an integer. If it works inputIsNumber will be true, and the studentIdInt will be available as a variable. 
            if(inputIsNumber == false){
                txtboxIDStu.Text = "Please enter a valid number";
                return; //Bail out if we can't turn the string into a number
            }
            Student s1 = new Student(studentIdInt); //We're going to use the ID we created to build the student using the constructor
            
            txtboxIDStu.Text = s1.fname + " " + s1.lastname; // By the time we've gotten here the constructor has fired, which also fired SelectDB() on that student. This just prints the name of the student, but if you want to improve this look up "Overrides" and create a ToString() override on your Student class.
        }
 
