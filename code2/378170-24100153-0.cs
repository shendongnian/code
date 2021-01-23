        public static bool IsCorrectRowHandle(GridView view, int rowHandle)
        {
            bool result = false;
            try
            {
                System.Data.DataRow row = view.GetDataRow(rowHandle);
                if (row != null)
                    result = true;
            }
            catch
            {
                return result;
            }
            return result;
        }
