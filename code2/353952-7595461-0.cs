        StreamReader ar = new StreamReader(@"C:\Users\arash\Desktop\problem1 (3).in");
        // Load a line into s
        string s = ar.ReadLine();
        while (s != null)
        {
            // Split on space
            string[] spl = s.Trim(' ').Split(' ');
            // Declare two variables to hold the numbers
            int one;
            int two;
            // Try to parse the strings into the numbers and display the sum
            if ( int.TryParse( spl[0], out one ) && int.TryParse( spl[1], out two) ) {
                MessageBox.Show( (one + two).ToString() )
            }
            // Error if the parsing failed
            else {
                MessageBox.Show("Error: Numbers were not in integer format");
            }
            // Read the next line into s
            s = ar.ReadLine();
        }
