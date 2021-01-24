    string date = "310319";
            string time = "174252";
            DateTime dt;
            
            bool correct = DateTime.TryParseExact(date + time, 
                                          "ddMMyyHHmmss", 
                                          CultureInfo.InvariantCulture, 
                                          DateTimeStyles.AdjustToUniversal,
                                          out dt); 
            
            Console.WriteLine(dt);
            
            
            DateTimeOffset dto = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            
            dto = new DateTimeOffset(dt, TimeSpan.Zero);
            long y =  dto.ToUnixTimeSeconds();
         
            Console.WriteLine(y); // output 1554054172
