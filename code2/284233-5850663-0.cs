    //---------------------------------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Formats from bytes to KB,MB,GB,TB 
            /// </summary>
            /// <param name="number">Bytes to format</param>
            /// <returns></returns>
            public static string AutoFileSize(long number)
            {
                double tmp = number;
                string suffix = " B ";
                if (tmp > 1024) { tmp = tmp / 1024; suffix = " KB"; }
                if (tmp > 1024) { tmp = tmp / 1024; suffix = " MB"; }
                if (tmp > 1024) { tmp = tmp / 1024; suffix = " GB"; }
                if (tmp > 1024) { tmp = tmp / 1024; suffix = " TB"; }
                return tmp.ToString("n") + suffix;
            }
