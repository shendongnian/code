            int count = 1;    
    private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
    
            var elements =
                from element in list
                select element;
    
            if(count <= elements.Count())
            {
                FName.Text = elements.ElementAt(count).fName;
                LName.Text = elements.ElementAt(count).lName;
                Phone.Text = elements.ElementAt(count).Phone;
                Gpa.Text = elements.ElementAt(count).Gpa.ToString();
    
                count++;
            }
        }
