    using (OleDbDataReader read = command.ExecuteReader())
    {
        // Reading information from the file.
        while (read.Read())
        {
            // Count all entries read from the reader.
            countEntries++;
    
            if (security.DecryptAES(read.GetString(1), 
                storedAuth.Password, storedAuth.UserName) 
                    == "PC Password")
            {
                // Count PC passwords.
                countPC++;
                PC.Tag = read.GetInt32(0);
                lvPC.Items.Add(PC);
            }
            else if (security.DecryptAES(read.GetString(1), 
                storedAuth.Password, storedAuth.UserName) 
                    == "Web Site Password")
            {
                countWeb++;
                Web.Tag = read.GetInt32(0);
                lvWeb.Items.Add(Web);
            }
            else if (security.DecryptAES(read.GetString(1), 
                storedAuth.Password, storedAuth.UserName) 
                    == "Serial Code")
            {
                countSerial++;
                Serial.Tag = read.GetInt32(0);
            }
        }
    }
    
    tabPage1.Text = "PC Passwords ( " + countPC + " )";
    tabPage2.Text = "Web Site Passwords ( " + countWeb + " )";
    tabPage3.Text = "Serial Codes ( " + countSerial + " )";
