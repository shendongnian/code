        void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            int z = 0;
            while (z != bp)
            {
                e.HasMorePages = true;
                z++;
            }
            e.HasMorePages = false;
        }
