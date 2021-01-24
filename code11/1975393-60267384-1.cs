            private void btnSaveData_Click(object sender, EventArgs e) {
                  StreamReader sr =  new 
                  StreamReader("INCIDENT.txt"); 
                   int num = sr.Peek();
                   sr.Close();
                   // here will assign last value in num
                  txtID.Text = ( num + 1 ).ToString();
                  // here add 1 to num and display result in textBox and you should save last value to use it later
                   StreamWriter sw = new StreamWriter("INCIDENT.txt");
                   sw.Write( ( num + 1 ).ToString() );
                   // here save last value you get to increment this value when you read TextFile again
                   sw.Fush();
                   sw.Close();
        }
