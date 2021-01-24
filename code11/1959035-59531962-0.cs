    public void invoiceno()
    {
        try
        {
            string c;
            var sql = "SELECT MAX(invoid) FROM sales";
            var cmd = new SqlCommand(sql, con);
            var maxInvNum = (int)cmd.ExecuteScalar() + 1;
    
            label4.Text = $"E-{maxInvNum:000000}";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.Write(ex.StackTrace);
        }
    }
