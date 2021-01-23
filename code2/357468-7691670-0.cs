    using (StreamReader sr = new StreamReader(file))
    {
       string line = sr.ReadLine();
       while( line != null ){
         if( line.StartsWith( "PA11" ) ){
            string[] parts = line.Split( " " );
            List<string> parameterList = new List<string>(parts);
            foreach (string s in parameterList)
                    listBox1.Items.Add(s);
          }
        }
    }
