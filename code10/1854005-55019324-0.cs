    private void button6_Click_1(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("Are you sure to send email to all customers?(check code)", "Warning", MessageBoxButtons.YesNo);​
        if (dialogResult == DialogResult.Yes)​
        {
            DoButtonTask();​
        }​
    }​​
    private class Customer
    {
        public string CustomerID {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string SendOffersBy_Email {get; set;}     
    }
    private List<Customer> getCustomers(string query)
    {
        List<Customer> output = new List<Customer>();
        try​
        {        
            clsDBConnector dbConnector1 = new clsDBConnector();​
            OleDbDataReader dr1;​
            dbConnector1.Connect();​
    
            dr1 = dbConnector1.DoSQL(query);
    
            while (dr1.Read())
            {   
                Customer c = new Customer();
                c.CustomerID = Convert.ToString(dr1[0]);
                c.Name = dr1[2];
                c.Email = Convert.ToString(dr1[4]);​
                c.SendOffersBy_Email = Convert.ToString(dr1[5]);​
                output.Add(c);
            }​
        ​}
        catch (Exception ex)​
        {    ​
            MessageBox.Show(ex.ToString());​
        }​​
        finally
        {
            return output;
        }
    
    }
    private void DoButtonTask()
    {
        int minCustomerID = 40;
        int maxCustomerID = 1425;
        string  sqlStr1 = "SELECT CustomerID, DateAdded, FullName, PhoneNumber, EmailAddress, SendOffersByEmail"​ +
            " FROM Customer WHERE CustomerID >= " + minCustomerID + " and CustomerID < " + maxCustomerID + ";" ;​
        
        List<Customer> aCustomers = getCustomers(sqlStr1);
    
        foreach (customer in aCustomers)
        {
            string email = customer.Email;
            if (email == "na" || email == "na@na.co.uk" || email == "na@na.com" || email == "")​
            {
                //MessageBox.Show("Customer " + customer.CustomerID + " does not have an email linked.");​
            }​
            else
            {
                if (customer.SendOffersBy_Email == "yes" || customer.SendOffersBy_Email == "Yes")​
                {    
      ​             SendEmail(i, email, customer.Name);​
                }​
                else​
                {   ​
                    //MessageBox.Show("Customer " + CustomerID + " does not accept emails.");​
                }​
            }​
        }
    
        MessageBox.Show("Emails sent.");​
    }​​
    
    private void SendEmail(int i, string email, string name)​
    {    ​​
        try​
        {    ​
            MailMessage mail = new MailMessage();​
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");​
            mail.From = new MailAddress("myemail");​
            mail.To.Add(email);​
            mail.Subject = "PRICE DROP!! Have your iPhone repaired today.";​
            mail.Body = "Hi " + name + ",\n" + ​
                "Our iPhone 7 and iPhone 8 series screen prices have now dropped in price!" + ​
                " Reply to this email to have your iPhone booked in for repair today - the prices may go back up! " + ​
                " All of our repairs come with our 6 months warranty and we can come to you." + ​
                "\n\nKind regards,\n Your Mobile Phone & Tablet Repair Specialist." + ​
                "\n\nTel: \nWebsite: \nEmail: " + ​
                "\nFacebook: " + ​
                "\n\n\n Don't want to recieve offers anymore? Just reply to this email to let us know and we will take you off our mailing system."​;​​
    
            SmtpServer.Port = 587;​
            SmtpServer.Credentials = new System.Net.NetworkCredential("myemail", "mypassword");​
            SmtpServer.EnableSsl = true;​
            SmtpServer.Send(mail);​
            mail.Dispose();​
        }​
        catch (Exception ex)​
        {    ​
            MessageBox.Show(ex.ToString());​
        }​​
    }
