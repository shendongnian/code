    [HttpPost, ValidateAntiForgeryToken]
        public IActionResult MailboxRulesResults(List<string> data)
        {
           using (StreamReader sr = new StreamReader(file))
            {
                String line;
                // Read line by line
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);                
                }
            }
            ViewBag.TableHTML = line;
            ViewBag.Guid = data[1];
            return View();
        }
