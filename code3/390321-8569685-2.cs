        public override string GetVaryByCustomString(HttpContext context, string arg)
        {
            if (arg.Equals("FullURL", StringComparison.InvariantCultureIgnoreCase)
            {
                // Retrieves the page
                Page oPage = context.Handler as Page;
                int gameId;
                // If the GameID is not in the page, you can use the Controls 
                // collection of the page to find the specific usercontrol and 
                // extract the GameID from that.
                // Otherwise, get the GameID from the page
                
                // You could also cast above
                gameId = (MyGamePage)oPage.GameID;
                // Generate a unique cache string based on the GameID
                return "GameID" + gameId.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
