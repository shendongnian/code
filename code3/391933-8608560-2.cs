        public ActionResult ExportCSV(List<User> input)
        {
            using (MemoryStream output = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(output, Encoding.UTF8))
                {
                    foreach (User user in input)
                    {
                        writer.Write(user.firstattribute);
                        writer.Write(",");
                        writer.Write(user.secondattribute);
                        writer.Write(",");
                        writer.Write(user.thirdattribute);
                        writer.Write(",");
                        writer.Write(user.lastattribute);
                        writer.WriteLine();
                    }
                    writer.Flush();
                }
                output.Position = 0;
                return Controller.File(output, "text/comma-separated-values", "report.csv");
            }
        }
