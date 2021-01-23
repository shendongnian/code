        private bool isOrdered(IQueryable Data)
        {
            string query = Data.ToString();
            int pIndex = query.LastIndexOf(')');
            if (pIndex == -1)
                pIndex = 0;
            if (query.IndexOf("ORDER BY", pIndex) != -1)
            {
                return true;
            }
            return false;
        }
