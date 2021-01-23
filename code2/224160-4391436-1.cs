    static void Main(string[] args)
            {
                string pattern =
    @"Record #(?<RecordNumber>\d*) with LeadRecordID (?<LeadRecordId>\d*) and MTN of .* has (?<NumberOfErrors>\d*) errors:(?:\r\n|)*(?<Errors>(\s{3}.+(\r\n)*)+)";
                string message =@"Record #1 with LeadRecordID 4 and MTN of (813) 555-1234 has 4 errors:
       Shipping Street Address cannot be blank
       Shipping City cannot be blank
       Shipping Zipcode cannot be blank
       Errors exist in secondary records #2, #3, #4, record not processed. 
    Record #2 with LeadRecordID 5 and MTN of (813) 555-4321 has 1 errors:
       Shipping Street Address cannot be blank";
                MatchCollection mc = Regex.Matches(message, pattern);
                foreach (Match m in mc)
                {
                    Console.WriteLine("RecordNumber = \"{0}\"", m.Groups["RecordNumber"].Value);
                    Console.WriteLine("LeadRecordId = \"{0}\"", m.Groups["LeadRecordId"].Value);
                    Console.WriteLine("NumberOfErrors = \"{0}\"", m.Groups["NumberOfErrors"].Value);
                    Console.WriteLine("Errors = \"{0}\"", m.Groups["Errors"].Value);
                }
                Console.ReadLine();
            }
