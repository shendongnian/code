    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		 string str = "[(\"Browser\": \"Chrome73 (v 73.0)\"), (\"UserAgent\": \"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.86 Safari/537.36\"), (\"Languages\": [\"nb-NO\", \"nb;q=0.9\", \"no;q=0.8\", \"nn;q=0.7\", \"en-US;q=0.6\", \"en;q=0.5\"]), (\"UserClaim-1-http://schemas.microsoft.com/ws/2008/06/identity/claims/role\": \"Admin\"), (\"SessionId\": \"hhaztuwfpyuobfslljuy4z4e\"), (\"Cookie-__RequestVerificationToken\": \"9MJm_A4agsgbe4c_JtAePFnfMLBEgnkc0XhROfDFVd6291SUGtLPAqprsGHBcJw9JDRde6UR_1jHY_Hr4oKi4OZzuUDXqAA6IfeEtr9sxVI1\"), (\"Cookie-.ASPXAUTH\": \"AA23B2B1A5C428BFB60E32EA5A78A7D5016D7586F88548C012A1C2C2EB2A34D40A959B43680BCCE9923F1890017F59A3A82E6C1121AF50CF226D638FBCBC40F2D8E2FE4C945B44CC7572717D56C71FCC0B7B285A0EB5379370ADC6BE970E6438\"), (\"Cookie-ASP.NET_SessionId\": \"hhaztuwfpyuobfslljuy4z4e\"), (\"Info-FamilyId\": 21267), (\"Info-LoggedInUserID\": 1), (\"Info-MainConsultantUserId\": 3)]";
             showMatch(str, @"(?<=\()(.*?)(?=\)[,\]])");
    	}
    	
    	 private static void showMatch(string text, string expr) {
             MatchCollection mc = Regex.Matches(text, expr);
             
             foreach (Match m in mc) {
                Console.WriteLine(m);
             }
          }
    }
