            foreach (var memb in membersreports)
            {
                try
                {
                    Console.WriteLine(memb.DOB);
                }
                catch (Exception ex)
                {
                    //set a breakpoint here or in the try block
                    Console.WriteLine(ex.Message);
                }
            }
