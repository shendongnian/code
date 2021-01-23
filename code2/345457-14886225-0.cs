                // Insert Colons on MAC
                string MACwithColons = "";
                for (int i = 0; i < MAC.Length; i++)
                {
                    MACwithColons = MACwithColons + MAC.Substring(i, 2) + ":";
                    i++;
                }
                MACwithColons = MACwithColons.Substring(0, MACwithColons.Length - 1); // Remove the last colon
