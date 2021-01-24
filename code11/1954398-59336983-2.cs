        public static bool i = false;
        //changed the method name to be more descriptive for the event
        private void BtnToggleDarkMode_Click(object sender, EventArgs e)
        {
             i = !i; // toggle the boolean, this can go after the else as well.
             //If true 
             if(i) {
                 //Do sth
             }
             else{
                 //do sth else
             }
        }
