    public class DotNetTips
    {
        private void DoSomeOperation()
        {
            using (var con1 = new SqlConnection("First Connection String"),
                       con2 = new SqlConnection("Second Connection String"))
            {
                // Rest of the code goes here
            }
        }
        private void DoSomeOtherOperation()
        {
            using (SqlConnection con = new SqlConnection("Connection String"))
            using (SqlCommand cmd = new SqlCommand())
            {
                // Rest of the code goes here
            }
        }
    }
