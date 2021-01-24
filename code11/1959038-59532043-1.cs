public void invoiceno()
{
    try
    {
        string c;
        var sql = "SELECT MAX(invoid) FROM sales";
        var cmd = new SqlCommand(sql, con);
        var maxInvId = cmd.ExecuteScalar() as string;
        if(maxInvId == null)
        {
            c = "E-000001";
        }
        else
        {
            int intVal = Int.Parse(maxInvId.Substring(2, 6));
            intVal ++;
            c = String.Format("E-{0:000000}", intVal);
        }
        label4.Text = c;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
        Console.Write(ex.StackTrace);
    }
}
