    public class User
    {
        public string Name { get; set; }
        public int ID { get; set; }
    } 
    
    static void Main(string[] args)
    {
        string xml =
            "<WebServices ErrorFound='False' ServerDateTime='30/11/2010 14:58:58'>" +
                "<Results>" +
                    "<Users TotalResults='5'>" +
                        "<UserName UserID='2'>John</UserName>" +
                        "<UserName UserID='3'>Dave</UserName>" +
                        "<UserName UserID='4'>Jim</UserName>" +
                        "<UserName UserID='5'>Bob</UserName>" +
                        "</Users>" +
                "</Results>" +
            "</WebServices>";
    
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
    
        var users = from userNameElement in doc.SelectNodes("/WebServices/Results/Users/UserName").OfType<XmlElement>()
                    select new User
                    {
                        Name = userNameElement.InnerText,
                        ID = Int32.Parse(userNameElement.GetAttribute("UserID"))
                    };
    
        foreach (var user in users)
        {
            Console.WriteLine(user.ID.ToString() + ": " + user.Name);
        }
    }
