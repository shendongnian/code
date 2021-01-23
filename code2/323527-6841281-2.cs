        private static string Move(string s)
        {
            if (s == "move")
                return "doMove"; // here could be some more action...
            return null;
        }
        private static string Query(string s)
        {
            if (s == "point")
                return "queryPoint"; // here could be some more action...
            return null;
        }
