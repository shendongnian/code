        /// <summary>
        /// Produces html for a pagination control.
        /// </summary>
        /// <param name="page">Page number for the current page (1-based index).</param>
        /// <param name="pageSize">Number or items per page.</param>
        /// <param name="totalItems">Total number of items across all pages.</param>
        /// <returns>Html of a pagination control.</returns>
        public string RenderPaginationControl(int page, int pageSize, int totalItems)
        {
            int totalPages = (int)Math.Ceiling((double)totalItems/pageSize);
            // Create pager.
            StringBuilder pagerSb = new StringBuilder();
            for (int i = 1; i <= totalPages; ++i)
            {
                // If it is NOT a link to current page.
                if (i != page) { pagerSb.Append(string.Format("<a href='/data.aspx?page={0}'>{0}</a>", i)); }
                // If it is the link to current page.
                else { pagerSb.Append(string.Format("<span>{0}</span>", i)); }
            }
            return pagerSb.ToString();
        }
