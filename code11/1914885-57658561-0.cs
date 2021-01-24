    using (StreamReader reader = new StreamReader("filename"))
            {
                while (true)
                {
                    string line = await reader.ReadLineAsync();
                    if (line == null)
                    {
                        break;
                    }
                    //logic here...
                }
            }
