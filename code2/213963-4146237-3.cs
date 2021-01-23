    private static FileResult iCalResult(string ics)
            {
                return new FileStreamResult(WriteiCal(ics),"text/calendar");
            }
    private static Stream WriteiCal(string iCalStream)
            {
    byte[] byteArray = Encoding.ASCII.GetBytes(iCalStream);
                MemoryStream stream = new MemoryStream(byteArray);
                return stream;
            }
