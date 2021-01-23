	        using (StreamReader sr = new StreamReader("TestFile.txt"))
            {
                String line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
		           string[] ipandport = line.split(":");
		           lstBoxIp.Items.Add( ipandport[0] );
		           lstBoxPort.Items.Add( ipandport[1] );
                }
            }
